using Store.Fill;
using Store.Model;
using Xunit;

namespace Store.UnitTest {

    public class FillConstantTest {

        /*------------------------ PROPERTY REGION ------------------------*/
        private IDataFiller _dataFiller = new FillConstant();
        private DataContext _dataContext = new DataContext();

        /*------------------------ METHODS REGION ------------------------*/
        private void prepareData() {
            _dataFiller.Fill(_dataContext);
        }

        [Fact]
        public void FillTest() {
            prepareData();

            Client client = new Client(FillConstant.CLIENT_ARRAY[0],
                FillConstant.CLIENT_ARRAY[1], FillConstant.CLIENT_ARRAY[2],
                FillConstant.CLIENT_ARRAY[3]);

            Product product = new Product(FillConstant.PRODUCT_ARRAY[0],
                FillConstant.PRODUCT_ARRAY[1], FillConstant.PRODUCT_ARRAY[2]);

            Warehouse warehouse = new Warehouse(product, FillConstant.WAREHOUSE_ARRAY[0],
                FillConstant.WAREHOUSE_ARRAY[1]);

            Invoice invoice = new Invoice(warehouse, client, FillConstant.STATIC_TIME);

            _dataContext.Clients[0].Equals(client);
            _dataContext.Warehouses[0].Equals(warehouse);
            _dataContext.Invoices[0].Equals(invoice);

            Assert.Equal(client, _dataContext.Clients[0]);
            Assert.Equal(warehouse, _dataContext.Warehouses[0]);
            Assert.Equal(_dataContext.Invoices[0], invoice);
        }

    }

}
