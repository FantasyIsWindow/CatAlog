﻿using CatAlog_App.DbWorker.DtoModels;

namespace CatAlog_App.GUI.Models
{
    public class PairModel : ModelBase
    {
        internal DtoPairModel _pairModel;

        public PairModel(DtoPairModel pairModel)
        {
            _pairModel = pairModel;
        }

        public PairModel()
        {
            _pairModel = new DtoPairModel();
        }

        public int Id
        {
            get => _pairModel.Id;
            set
            {
                _pairModel.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get => _pairModel.Name;
            set
            {
                _pairModel.Name = value;
                OnPropertyChanged("Name");
            }
        }

        internal DtoPairModel GetModel() => _pairModel;
    }
}
