﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfCakeTest.Command;
using WpfCakeTest.Model;

namespace WpfCakeTest.ViewModel
{
    class MainWindowViewModel:ViewModelBase<MainWindowModel>
    {
        //private DocumentViewModel document;
        //public DocumentViewModel CurrentDocument
        //{
        //    get => document;
        //    set
        //    {
        //        if (document != null)
        //        {
        //            document.Pages.CollectionChanged -= PagesChanged;
        //            document.PropertyChanged -= DocumentPropertyChanged;
        //        }
        //        document = value;
        //        Model.Document = document.Model;
        //        Subscribe();
        //        OnPropertyChanged(nameof(CurrentDocument));
        //        UpdatePageText();
        //    }
        //}
        //public ObservableCollection<Color> FavoriteColors => Model.FavouriteColors;
        public ObservableViewModelCollection<ToolViewModel, Tool> Tools { get; set; }
        private int selectedToolIndex;

        public int SelectedToolIndex
        {
            get => selectedToolIndex;
            set
            {
                if (value >= 0 && value < Tools.Count || Tools.Count == 0)
                {
                    selectedToolIndex = value;
                    RaisePropertyChanged(nameof(SelectedToolIndex));
                    RaisePropertyChanged(nameof(SelectedTool));
                    ToolViewModel.UpdateCursorIfEraser(SelectedTool);
                }
                else
                {
                    // throw new IndexOutOfRangeException("out of range ;(");//试一试有无注释的效果
                }
            }
        }
        public ToolViewModel SelectedTool
        {
            get => Tools[SelectedToolIndex];
            set
            {
                int find = Tools.IndexOf(value);
                SelectedToolIndex = find;
            }
        }
        //private void Subscribe() // To my youtube channel XD
        //{
        //    document.Pages.CollectionChanged += PagesChanged;
        //    document.PropertyChanged += DocumentPropertyChanged;
        //}

        //private void DocumentPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    UpdatePageText();
        //    UpdatePageManipulation();
        //}

        //private void UpdatePageManipulation()
        //{
        //    PreviousPageCommand.RaiseCanExecuteChanged();
        //    NextPageCommand.RaiseCanExecuteChanged();
        //    DeletePageCommand.RaiseCanExecuteChanged();
        //}

        //private void PagesChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    UpdatePageText();
        //}
        //public DelegateCommand PreviousPageCommand { get; private set; }
        //public DelegateCommand NextPageCommand { get; private set; }
        //public DelegateCommand NewPageCommand { get; private set; }
        //public DelegateCommand DeletePageCommand { get; private set; }
        //public DelegateCommand ExtendPageCommand { get; private set; }
        public DelegateCommand SetToolByNameCommand { get; private set; }//???
        //public string PageDisplayText => CurrentDocument.SelectedIndex + 1 + "/" + CurrentDocument.Pages.Count;

        public MainWindowViewModel() : base()
        {
            Initalize();
        }
        public MainWindowViewModel(MainWindowModel model) : base(model)
        {
            Initalize();
        }
        //private void UpdatePageText()
        //{
        //    RaisePropertyChanged(nameof(PageDisplayText));
        //}
        private void Initalize()
        {
            //document = new DocumentViewModel(Model.Document);
            Tools = new ObservableViewModelCollection<ToolViewModel, Tool>(Model.Tools, t => new ToolViewModel(t));
            //Subscribe();//???
            //PreviousPageCommand = new DelegateCommand(o => ChangePage(Direction.Backwards), o => CanChangePage(Direction.Backwards));
            //NextPageCommand = new DelegateCommand(o => ChangePage(Direction.Forwards), o => CanChangePage(Direction.Forwards));
            //NewPageCommand = new DelegateCommand(o => CreateNewPage());
            //DeletePageCommand = new DelegateCommand(o => DeletePage(CurrentDocument.SelectedIndex), o => CanDeletePage);
            //ExtendPageCommand = new DelegateCommand(o => ExtendPage(o.ToString()));
            SetToolByNameCommand = new DelegateCommand(o => SetToolByName(o.ToString()), o => IsNameValid(o.ToString()));
        }

        private void SetToolByName(string name)
        {
            if (!IsNameValid(name))
            {
                return;
            }
            SelectedTool = Tools.First(t => t.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
        private bool IsNameValid(string name)
        {
            return Tools.Any(t => t.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        //private void DeletePage(int index)
        //{
        //    if (CanDeletePage)
        //    {
        //        CurrentDocument.Pages.RemoveAt(index);
        //        UpdatePageManipulation();
        //        if (index == 0)
        //        {
        //            CurrentDocument.SelectedIndex = CurrentDocument.SelectedIndex; // Update the deleted page :v
        //        }
        //    }
        //}
        //private void ExtendPage(string direction)//???
        //{
        //    if (direction.Equals("Right", StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        CurrentDocument.SelectedPage.Width += 350;
        //    }
        //    if (direction.Equals("Bottom", StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        CurrentDocument.SelectedPage.Height += 350;
        //    }
        //}
        //private bool CanDeletePage => CurrentDocument.Pages.Count > 1;
        //private void ChangePage(Direction direction)
        //{
        //    if (CanChangePage(direction))
        //    {
        //        document.SelectedIndex += (int)direction;
        //    }
        //}
        //private void CreateNewPage()
        //{
        //    CurrentDocument.Pages.Add(new PageViewModel());
        //    ChangePage(Direction.Forwards);
        //}
        //private bool CanChangePage(Direction direction)
        //{
        //    return (direction == Direction.Forwards && document.SelectedIndex + 1 != document.Pages.Count) ||
        //           (direction == Direction.Backwards && document.SelectedIndex - 1 >= 0);
        //}
        //private enum Direction
        //{
        //    Forwards = 1,
        //    Backwards = -1
        //}
    }
}
