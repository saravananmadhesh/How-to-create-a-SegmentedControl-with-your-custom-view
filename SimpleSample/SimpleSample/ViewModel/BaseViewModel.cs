using Syncfusion.XForms.Border;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SimpleSample.SegmentedControl
{
    public class DataModel
    {
        public string XData { get; set; }
        public double YData { get; set; }
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GridModel> PhotoGridAlign { get; set; }
        public ObservableCollection<GridModel> VideoGridAlign { get; set; }
        public ObservableCollection<GridModel> DocGridAlign { get; set; }

        public List<FontImageSource> SourceCollection { get; set; }
        public ObservableCollection<View> CustomViews { get; set; }

        private ContentView content;
        public ContentView ContentView
        {
            get { return content; }
            set
            {
                content = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ContentView"));
            }
        }


        private int selectedIndex = 0;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                }
                if (selectedIndex == 0)
                {
                    ContentView = new PhotoLayout(this);
                }
                else if (selectedIndex == 1)
                {
                    ContentView = new VideoLayout(this);
                }
                else if (selectedIndex == 2)
                {
                    ContentView = new DocLayout(this);
                }

                ChangeSelectedImageColor(value);

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedIndex"));
            }
        }

        private void ChangeSelectedImageColor(int value)
        {
            if(value == -1)
            {
                foreach(var s in SourceCollection)
                {
                    s.Color = Color.Accent;
                }
            }
            else
            {
                for (int i = 0; i < SourceCollection.Count; i++)
                {
                    if (i == value)
                        SourceCollection[i].Color = Color.FromHex("#03b6fc");
                    else
                        SourceCollection[i].Color = Color.Accent;
                }
            }
        }

        public BaseViewModel()
        {
            CustomViews = new ObservableCollection<View>();
            string fontfamily = "FontAwesome5Pro-Regular";
            if (Device.RuntimePlatform == Device.Android)
            {
                fontfamily = "FontAwesome.otf#FontAwesome5Pro-Regular";
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                fontfamily = "/Assets/FontAwesome.otf#FontAwesome5Pro-Regular";
            }

            Image photo = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            Image video = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            Image doc = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            SourceCollection = new List<FontImageSource>()
            {
             new FontImageSource()
            {
                FontFamily = fontfamily,
                Glyph = "\uf03e",
                //Glyph = "\uf148",
                Size = 25,
                Color = Color.Accent,
            },
             new FontImageSource()
            {
                FontFamily = fontfamily,
                //Glyph = "\uf149",
                Glyph = "\uf03d",
                Size = 25,
                Color = Color.Accent,
            },
             new FontImageSource()
            {
                FontFamily = fontfamily,
                Glyph = "\uf001",
                Size = 25,
                Color = Color.Accent,
            }

           };

            photo.Source = SourceCollection[0];
            video.Source = SourceCollection[1];
            doc.Source = SourceCollection[2];

            var stack_1 = new StackLayout() { Orientation = StackOrientation.Horizontal };
            stack_1.Children.Add(photo);
            var stack_2 = new StackLayout() { Orientation = StackOrientation.Horizontal};
            stack_2.Children.Add(video);
            var stack_3 = new StackLayout() { Orientation = StackOrientation.Horizontal };
            stack_3.Children.Add(doc);
            CustomViews.Add(stack_1);
            CustomViews.Add(stack_2);
            CustomViews.Add(stack_3);

            PhotoGridAlign = new ObservableCollection<GridModel>()
            {
                new GridModel(){GridColumn=0, GridRow=0},
                new GridModel(){GridColumn=1, GridRow=0},
                new GridModel(){GridColumn=2, GridRow=0},
                new GridModel(){GridColumn=0, GridRow=1},
                new GridModel(){GridColumn=1, GridRow=1},
                new GridModel(){GridColumn=2, GridRow=1},
                new GridModel(){GridColumn=0, GridRow=2},
                new GridModel(){GridColumn=1, GridRow=2},
                new GridModel(){GridColumn=2, GridRow=2},
                new GridModel(){GridColumn=0, GridRow=3},
                new GridModel(){GridColumn=1, GridRow=3},
                new GridModel(){GridColumn=2, GridRow=3},
            };

            VideoGridAlign = new ObservableCollection<GridModel>()
            {
                new GridModel(){GridColumn = 0, GridRow = 0},
                new GridModel(){GridColumn = 0, GridRow = 1},
                new GridModel(){GridColumn = 0, GridRow = 2},
                new GridModel(){GridColumn = 0, GridRow = 3},
                new GridModel(){GridColumn = 0, GridRow = 4},
                new GridModel(){GridColumn = 0, GridRow = 5},
            };

            DocGridAlign = new ObservableCollection<GridModel>()
            {
                new GridModel(){GridColumn=0, GridRow=0},
                new GridModel(){GridColumn=1, GridRow=0},
                new GridModel(){GridColumn=0, GridRow=1},
                new GridModel(){GridColumn=1, GridRow=1},
                new GridModel(){GridColumn=0, GridRow=2},
                new GridModel(){GridColumn=1, GridRow=2},
                new GridModel(){GridColumn=0, GridRow=3},
                new GridModel(){GridColumn=1, GridRow=3},
            };

            SelectedIndex = 0;
        }
      

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class GridModel
    {
        public int GridRow { get; set; }
        public int GridColumn { get; set; }
    }
}
