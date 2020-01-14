# How-to-create-a-SegmentedControl-with-your-custom-view

SegmentedControl provides support to add any custom view as their segment by populating collections of custom views as ItemsSource.

The code below shows how to add image view collection as segmented items

ViewModel:
public class ViewModel
{
        public ObservableCollection<View> CustomViews { get; set; }
         string fontfamily = "FontAwesome5Pro-Regular";
        public ViewModel()
        {
            CustomViews = new ObservableCollection<View>();
Image photo = new Image();
            Image video = new Image();
            Image music = new Image();

FontImageSource  photo.Source = new FontImageSource() { FontFamily = fontfamily, Glyph = "\uf1c5",  Size = 24, Color = Color.Black, };
FontImageSource  video.Source = new FontImageSource() { FontFamily = fontfamily, Glyph = "\uf1c8", Size = 24, Color = Color.Black, };
FontImageSource  music.Source = new FontImageSource() { FontFamily = fontfamily, Glyph = "\uf1c3", Size = 24, Color = Color.Black, };

            CustomViews.Add(photo);
            CustomViews.Add(video);
            CustomViews.Add(music);
        }
}

XAML:
<sfbutoon:SfSegmentedControl
    HeightRequest="40"
    HorizontalOptions="Center"
    VerticalOptions="Center"
    x:Name="segmentedControl"
    VisibleSegmentsCount="3"
    Color="Transparent"
    CornerRadius="10"
    SelectedIndex="1”
    ItemsSource="{Binding CustomViews}">
    
</sfbutoon:SfSegmentedControl>

 
