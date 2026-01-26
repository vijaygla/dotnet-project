using System.Collections.Generic;
using EduResultsRankGenerator.Models;

namespace EduResultsRankGenerator.Services
{
    public class RankGeneratorService
    {
        private readonly MergeSortService _mergeSortService;

        public RankGeneratorService()
        {
            _mergeSortService = new MergeSortService();
        }

        public List<Student> GenerateRankList(List<List<Student>> districtLists)
        {
            List<Student> combinedList = new();

            foreach (var district in districtLists)
            {
                combinedList.AddRange(district);
            }

            return _mergeSortService.MergeSort(combinedList);
        }
    }
}
