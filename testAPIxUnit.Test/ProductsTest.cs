using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using ProductAPI.Contexts;
using ProductAPI.Domains;
using ProductAPI.Interfaces;
using ProductAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace testAPIxUnit.Test
{
    public class ProductsTest
    {
        //Indica que o metodo e de teste de unidade
        [Fact]
        public void Get()
        {
            //Arrange : Organizar (Cenario)


            var product = new List<Product>
                {
                    new Product {IdProduct = Guid.NewGuid(), Name = "Produto1", Price = 12},
                    new Product {IdProduct = Guid.NewGuid(), Name = "Produto2", Price = 24},
                    new Product {IdProduct = Guid.NewGuid(), Name = "Produto3", Price = 36}
                };


            //Cria um objeto de simulacao do tipo IProductsRepository
            var mockRepository = new Mock<IProductRepository>();

            //Configura o metodo GetAll para retornar a lista de product
            mockRepository.Setup(x => x.GetAll()).Returns(product);



            //Act : Agir

            //Chama o metodo GetAll() e armazena o resultado e result
            var result = mockRepository.Object.GetAll();

            //Assert : Provar

            //Prova se o resultado esperado e igual ao resultado obtido atraves da busca
            Assert.Equal(3, result.Count);

        }

        [Fact]
        public void Create()
        {
            var product = new Product { IdProduct = Guid.NewGuid(), Name = "Bola de basquete", Price = 120 };

            var mockRepository = new Mock<IProductRepository>();


            mockRepository.Object.Create(product);


            ///Times.Once
            //Descrição: Times.Once é um valor de enumeração que especifica quantas vezes o método
            //Create deve ter sido chamado com o argumento que corresponde às condições fornecidas.
            //Times.Once significa que o método deve ter sido chamado exatamente uma vez.

            ///It.Is<Product>(p => p.Name == "NovoProduto" && p.Price == 50)
            //Descrição: It.Is<Product>(...) é um método de Moq que permite especificar uma condição para o argumento que foi passado para o método que você está verificando.
            mockRepository.Verify(x => x.Create(It.Is<Product>(p => p.Name == "Bola de basquete" && p.Price == 120)), Times.Once);
        }

        ///OUTRA FORMA DE REALIZAR O METODO
        //public void Post()
        //{
        // Arrange: Configura o cenário de teste, criando um novo produto e configurando o mock do repositório.


        //var newProduct = new Products { ID = Guid.NewGuid(), Name = "Smartfone", Price = 5000 };

        // Cria um mock do repositório de produtos utilizando a biblioteca Moq.
        //var mockRepository = new Mock<IProductsRepository>();

        // Configura o mock para que, quando o método Create() for chamado com o newProduct,
        // ele seja tratado como uma operação válida (Verifiable indica que esta ação será verificada).
        //mockRepository.Setup(x => x.Create(newProduct)).Verifiable();

        // Act: Executa a ação que está sendo testada, que neste caso é chamar o método Create() 

        //mockRepository.Object.Create(newProduct);

        // Assert: Verifica se o método Create() foi realmente chamado com o produto correto.
        // O Verify() confirma que o método Create() foi chamado exatamente uma vez (Times.Once)
        // com o objeto newProduct durante a execução do teste.
        //mockRepository.Verify(x => x.Create(newProduct), Times.Once);
        //}



        [Fact]
        public void Delete()
        {
            var productId = Guid.NewGuid();

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Object.Delete(productId);

            mockRepository.Verify(x => x.Delete(It.Is<Guid>(id => id == productId)), Times.Once);
        }


        [Fact]
        public void Update()
        {
            var productId = Guid.NewGuid();
            var product = new Product { IdProduct = productId, Name = "Produto", Price = 5 };
            var productAtt = new Product { IdProduct = productId, Name = "ProdutoAtualizado", Price = 50 };

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.Update(productId, productAtt)).Verifiable();
            
            mockRepository.Object.Update(productId, productAtt);

            mockRepository.Verify(x => x.Update(productId, productAtt), Times.Once);
        }

    }
}
