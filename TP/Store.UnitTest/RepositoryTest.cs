using System;
using System.Linq;
using Store.Exception;
using Store.Fill;
using Store.Model;
using Store.Repository;
using Xunit;

namespace Store.UnitTest {

    public class RepositoryTest {

        /*------------------------ PROPERTY REGION ------------------------*/
        private DataRepository _dataRepository;

        private Client _client = new Client("John", "Smith",
            "JohnSmith@gmail.com", "USA");

        private readonly string JAMES = "James";

        /*------------------------ METHODS REGION ------------------------*/
        private void BeforeEach() {
            _dataRepository = new DataRepository(new FillConstant());
        }

        private void BeforeEachAndAddClient() {
            BeforeEach();
            _dataRepository.Add(_client);
        }

        [Fact]
        public void AddClientTest() {
            BeforeEach();
            Assert.Equal(1, _dataRepository.GetAllClients().Count());

            _dataRepository.Add(_client);
            Assert.Equal(2, _dataRepository.GetAllClients().Count());
        }

        [Fact]
        public void DeleteClientTest() {
            BeforeEach();
            Assert.Equal(1, _dataRepository.GetAllClients().Count());

            _dataRepository.Add(_client);
            Assert.Equal(2, _dataRepository.GetAllClients().Count());

            _dataRepository.Delete(_client);
            Assert.Equal(1, _dataRepository.GetAllClients().Count());
        }

        [Fact]
        public void GetClientTest() {
            BeforeEachAndAddClient();
            Assert.Equal(_client, _dataRepository.GetClient(_client.Id));
        }

        [Fact]
        public void GetAllClientsTest() {
            BeforeEachAndAddClient();
            Assert.Equal(2, _dataRepository.GetAllClients().Count());
        }

        [Fact]
        public void UpdateClientTest() {
            BeforeEachAndAddClient();

            _client.FirstName = JAMES;
            _dataRepository.Update(_client.Id, _client);

            Assert.Equal(JAMES, _dataRepository.GetClient(_client.Id).FirstName);
        }

        [Fact]
        public void UpdateClientExceptionTest() {
            BeforeEachAndAddClient();

            _client.FirstName = JAMES;
            Assert.Throws<InvalidIdException>(
                () => _dataRepository.Update(new Guid(), _client));
        }

    }

}
