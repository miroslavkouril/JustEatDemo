
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Threading;

namespace JustEatDemo
{
	public abstract class DownloadProgressFragment : Fragment, IDownloadProgressActions
	{
		protected Action DataDownloadFinished;

		private AlertDialog downloadInProgressDialog;
		private AlertDialog downloadFailedDialog;

		public abstract bool DataAreDownloaded { get; }

		public abstract void DownloadData();

		public override void OnStart()
		{
			base.OnResume();

			if (!DataAreDownloaded)
			{
				StartDownload();
			}
		}

		private void StartDownload()
		{
			new DowloadDataAsyncTask(this).Execute();
		}

		public override void OnStop()
		{
			base.OnStop();

			DismissDownloadInProgressDialog();
		}

		public void DisplayDownloadInProgressDialog()
		{
			DismissDownloadInProgressDialog();

			InitDownloadInProgressDialog();

			ShowDownloadInProgressDialog();
		}

		private void InitDownloadInProgressDialog()
		{
			View progressBar = (View) Activity.LayoutInflater.Inflate(Resource.Layout.DialogProgressBarView, null);

			downloadInProgressDialog = new AlertDialog
				.Builder(Activity, Resource.Style.ProgressDialogStyle)
				.SetView(progressBar)
				.SetCancelable(false)
				.Create();
		}

		private void ShowDownloadInProgressDialog()
		{
			downloadInProgressDialog.Show();
		}

		private bool ProgressDialogIsDisplayed()
		{
			return (downloadInProgressDialog != null) && downloadInProgressDialog.IsShowing;
		}

		public void DismissDownloadInProgressDialog()
		{
			if (ProgressDialogIsDisplayed())
			{
				downloadInProgressDialog.Dismiss();
				downloadInProgressDialog = null;
			}
		}

		public void DataDownloadFinishedAction()
		{
			if (DataDownloadFinished != null)
			{
				DataDownloadFinished();
			}
		}

		public void DisplayDownloadProblemDialog()
		{
			downloadFailedDialog =  new AlertDialog
				.Builder(Activity)
				.SetMessage(Resource.String.dialog_data_download_failed_message)
				.SetCancelable(false)
				.SetPositiveButton(Resource.String.dialog_data_download_failed_positive_text, StartDownloadAgain)
				.SetNegativeButton(Resource.String.dialog_data_download_failed_negative_text, NavigateBack)
				.Create();

			downloadFailedDialog.Show();
		}

		private void StartDownloadAgain(Object sender, DialogClickEventArgs e)
		{
			StartDownload();
		}

		private void NavigateBack(Object sender, DialogClickEventArgs e)
		{
			Activity.Finish();
		}
	}
}

