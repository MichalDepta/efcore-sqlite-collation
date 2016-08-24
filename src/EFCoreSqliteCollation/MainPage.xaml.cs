using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using EFCoreSqliteCollation.DataAccess;
using EFCoreSqliteCollation.Models;


namespace EFCoreSqliteCollation
{
    public sealed partial class MainPage : Page
    {
        private readonly EntitiesContext _entitiesContext = new EntitiesContext();
        private IEnumerable<MyEntity> _entities;

        public MainPage()
        {
            this.InitializeComponent();
        }

        public IEnumerable<MyEntity> Entities
        {
            get { return _entities; }
            set
            {
                _entities = value;
                EntitiesListView.ItemsSource = _entities;
            }
        }

        private void HandlePageLoaded(object sender, RoutedEventArgs e)
        {
            FillItems(string.Empty);
        }

        private void HandleSearch(object sender, RoutedEventArgs e)
        {
            var phrase = SearchPhraseTextView.Text;
            FillItems(phrase);
        }

        private void FillItems(string phrase)
        {
            IQueryable<MyEntity> query = _entitiesContext.Entities;

            if (!string.IsNullOrWhiteSpace(phrase))
            {
                query = query.Where(entity => entity.Name.Contains(phrase));
            }

            Entities = query.ToList();
        }
    }
}
