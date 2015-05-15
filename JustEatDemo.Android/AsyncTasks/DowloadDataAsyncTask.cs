using Android.OS;

namespace JustEatDemo
{
	public class DowloadDataAsyncTask : AsyncTask
	{
		private readonly IDownloadProgressActions downloadDataActions;

		public DowloadDataAsyncTask(IDownloadProgressActions downloadDataActions)
		{
			this.downloadDataActions = downloadDataActions;
		}

		protected override void OnPreExecute()
		{
			base.OnPreExecute();

			downloadDataActions.DisplayDownloadInProgressDialog();
		}

		protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
		{
			try 
			{
				downloadDataActions.DownloadData();

				return Java.Lang.Boolean.True;
			}
			catch
			{
				return Java.Lang.Boolean.False;
			}
		}

		protected override void OnPostExecute(Java.Lang.Object result)
		{
			base.OnPostExecute(result);

			downloadDataActions.DismissDownloadInProgressDialog();


			if (result == Java.Lang.Boolean.True)
			{
				downloadDataActions.DataDownloadFinishedAction();
			}
			else
			{
				downloadDataActions.DisplayDownloadProblemDialog();
			}
		}
	}
}