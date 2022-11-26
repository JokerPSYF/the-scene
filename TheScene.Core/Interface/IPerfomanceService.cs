﻿using TheScene.Core.Models.Common;
using TheScene.Core.Models.PerfomanceModels;

namespace TheScene.Core.Interface
{
    public interface IPerfomanceService
    {
        public Task<QueryModel<AllPerfomanceModel>> All(
           string? Genre = null, string? perfomanceType = null,
           string? searchTerm = null, PerfomanceSotring sorting = PerfomanceSotring.Title,
           int currentPage = 1, int eventPerPage = 5);

        public Task<int> Create(AddPerfomanceModel model);

        public Task Delete(int eventId);

        public Task<DetailPerfomanceModel> DetailsById(int eventId);

        public Task Edit(int eventId, EditPerfomanceModel model);

        public Task<bool> Exists(int eventId);
    }
}
