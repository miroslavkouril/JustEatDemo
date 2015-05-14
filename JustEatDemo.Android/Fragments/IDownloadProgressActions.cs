using System;

namespace JustEatDemo
{
	public interface IDownloadProgressActions
	{
		void DisplayDownloadInProgressDialog();
		void DismissDownloadInProgressDialog();

		void DownloadData();
		void DataDownloadFinishedAction();

		void DisplayDownloadProblemDialog();
	}
}

