using MyStoreProject.Logic;
using MyStoreProject.Pages.Body.TshirtsPages;
using MyStoreProject.Tools;
using NUnit.Framework;

namespace MyStoreProject.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SearchAndSortTests : TestRunner
    {
        [Test, TestCase("dresses")]
        public void GoToSearchPageSortProduct(string product)
        {
            //Arrange
            SearchAndSortMethods searchSort = new SearchAndSortMethods();
            string expectedResult1 = "DRESSES";
            string expectedResult2 = "$50.99";
            string expectedResult3 = "$16.51";
            string expectedResult4 = "Blouse";
            string expectedResult5 = "Printed Summer Dress";
            int expectedResult6 = 68;
            int expectedResult7 = 154;
            //Step 1
            string actualResult1 = searchSort.SearchProduct(product);
            Assert.AreEqual(actualResult1, expectedResult1, "Step 1 Used search");
            //Step 2 
            string actualResult2 = searchSort.SortProductsByPrice(ChooseBySortRepository.NameForSort[ChooseBySortFields.PriceHighestFirst]);
            Assert.AreEqual(actualResult2, expectedResult2, "Step 2: Sort by price lowest first");
            //Step 3
            string actualResult3 = searchSort.SortProductsByPrice(ChooseBySortRepository.NameForSort[ChooseBySortFields.PriceLowestFirst]);
            Assert.AreEqual(actualResult3, expectedResult3, "Step 3:Sort by price highest first");
            //Step 4        
            string actualResult4 = searchSort.SortProductsByName(ChooseBySortRepository.NameForSort[ChooseBySortFields.ProductNameAtoZ]);
            Assert.AreEqual(actualResult4, expectedResult4, "Step 4: Sort By product name A to Z");
            //Step 5
            string actualResult5 = searchSort.SortProductsByName(ChooseBySortRepository.NameForSort[ChooseBySortFields.ProductNameZtoA]);
            Assert.AreEqual(actualResult5, expectedResult5, "Step 5: Sort By product name Z to A");
            //Step 6
            int actualResult6 = searchSort.SortProductsByReference(ChooseBySortRepository.NameForSort[ChooseBySortFields.ReferenceHighestFirst]);
            Assert.AreEqual(actualResult6, expectedResult6, "Step 6: Sort By Reference Lowest first");
            //Step 7
            int actualResult7 = searchSort.SortProductsByReference(ChooseBySortRepository.NameForSort[ChooseBySortFields.ReferenceLowestFirst]);
            Assert.AreEqual(actualResult7, expectedResult7, "Step 7: Sort By Reference Highest first");
        }
    }
}
