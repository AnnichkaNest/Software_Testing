using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Data.SqlClient;
using AnalaizerClassLibrary;

namespace CalculatorTests
{
    [TestClass]
    public class UnaryTests
    {
        // Рядок підключення до твого локального сервера
        private string connectionString = @"Server=localhost\SQLEXPRESS;Database=CalculatorTestsDb;Trusted_Connection=True;TrustServerCertificate=True;";

        [TestMethod]
        public void TestReplaceUnaryPlusMinusFromDb()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT InputExpression, ExpectedResult FROM UnaryTests";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string input = reader.GetString(0);
                        string expected = reader.GetString(1);

                        // Викликаємо метод аналізатора
                        string actual = AnalaizerClass.ReplaceUnaryPlusMinus(input);

                        // Перевіряємо, чи збігається результат з тим, що в базі
                        Assert.AreEqual(expected, actual, $"Помилка на виразі: {input}");
                    }
                }
            }
        }
    }
}