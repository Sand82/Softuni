import CatalogItem from './CatalogItem/CatalogItem.js';

const Catalog = ({games}) => {
    return (
<section id="catalog-page">
          <h1>All Games</h1>          
          {games.length > 0
            ? games.map(x => <CatalogItem game={x} key={x._id}/>)
            : <h3 className="no-articles">No articles yet</h3>
          }
        </section>
    );
}

export default Catalog;