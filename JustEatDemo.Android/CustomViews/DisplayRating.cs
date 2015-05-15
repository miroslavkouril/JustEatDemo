using Android.Content;
using Android.Graphics;
using Android.Views;

namespace JustEatDemo
{
	public class DisplayRating : View
	{
		private float maxRating;
		private float rating;

		private int ratingStarSize;
		private int ratingStarSpace;

		private Paint paint;

		public DisplayRating(Context context, Android.Util.IAttributeSet attrs) : base(context, attrs)
		{
			var a = context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.DisplayRating, 0, 0);

			try 
			{
				maxRating = a.GetFloat(Resource.Styleable.DisplayRating_maxRating, Resources.GetInteger(Resource.Integer.rating_bar_max_rating));
				rating = a.GetFloat(Resource.Styleable.DisplayRating_rating, 0);
			} 
			finally 
			{
				a.Recycle();
			}

			ratingStarSize = Resources.GetDimensionPixelSize(Resource.Dimension.rating_bar_star_size);
			ratingStarSpace = Resources.GetDimensionPixelSize(Resource.Dimension.rating_bar_space_between_stars);

			paint = new Paint();
		}

		public float Rating
		{
			get
			{
				return rating;
			}
			set
			{
				this.rating = value;

				Invalidate();
				RequestLayout();
			}
		}

		public float MaxRating
		{
			get
			{
				return maxRating;
			}
			set
			{
				this.maxRating = value;

				Invalidate();
				RequestLayout();
			}
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			SetMeasuredDimension(widthMeasureSpec, heightMeasureSpec); 
		}

		protected override void OnDraw(Canvas canvas)
		{
			for (int i = 0; i < MaxRating; i++)
			{
				var d = Resources.GetDrawable(GetImageResource(i + 1));

				int offset = (i * ratingStarSize);
				if (i > 0)
				{
					offset += (i * ratingStarSpace);
				}

				d.SetBounds(offset, 0, ratingStarSize + offset, ratingStarSize);
				d.Draw(canvas);
			}
		}

		private int GetImageResource(int starIndex)
		{
			float diff = starIndex - rating;
			if (diff < 0.25)
			{
				return Resource.Drawable.ic_star_full;
			}
			else
			{
				if (diff >= 0.75)
				{
					return Resource.Drawable.ic_star_empty;
				}
				else
				{
					return Resource.Drawable.ic_star_half;
				}
			}
		}
	}
}