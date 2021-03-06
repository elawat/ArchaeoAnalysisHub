﻿using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.Data.Repository.Interfaces
{
    public interface IAnalysisRepository
    {
        List<Analysis> GetAll();
        List<Analysis> GetAllForHomeView(string query = null, int loadMultiplier = 1);
        Analysis GetAnalysis(int id);
        List<Sample> GetSamplesForUser(string userId);
        List<Artefact> GetArtefactsForUser(string userId);
        List<AnalysisType> GetAnalysisTypes();
        List<string> GetSymbols();
        void Update(AnalysisFormViewModel updateAnalysis);
        void Create(Analysis analysis);
        void Delete(int id);
        AnalysisDataPoint GetDataPoint(int id);
        void UpdateDataPoint(AnalysisDataPointFormViewModel updatedDataPoint);
        void DeleteDataPoint(int id);
        void CreateDataPoint(AnalysisDataPoint dataPoint);
        List<Analysis> GetAnalyses(List<int> analysesIds);
    }
}
