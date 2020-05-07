using System.Drawing;

namespace System.Windows.Forms
{
    public class TreeListViewSubItem : ListViewItem.ListViewSubItem
	{
		public Color BackgroundGradientStartColor { get; set; }
		public bool UseGradientBackground { get; set; }
		double _fill = 0.5;
		public double FillRatio { get { return _fill; }
			set 
			{
				if (value > 1)
				{
					_fill = 1;
				}
				else 
				{
					_fill = value;
				}
			} 
		}

	}
}
