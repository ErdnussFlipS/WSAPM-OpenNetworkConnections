using GitHubUpdateManger.Extensions;
using GitHubUpdateManger.Library;
using GitHubUpdateManger.Model;
using Octokit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUpdateManger
{
	public class GitHubUpdateManager
	{
		private Library.CustomOctokit.GitHubClient github;

		private string RepositoryName { get; set; }
		private string RepositoryOwnerName { get; set; }
        private string ReleaseVersionPattern { get; set; }

        public List<RepositoryRelease> Updates { get; private set; }

		public IApplicationUpdater ApplicationUpdater { get; set; }

		public GitHubUpdateManager(string repositoryName, string repositoryOwnerName, string releaseVersionPattern)
		{
			RepositoryName = repositoryName;
			RepositoryOwnerName = repositoryOwnerName;
            ReleaseVersionPattern = releaseVersionPattern;

			github = new Library.CustomOctokit.GitHubClient(new ProductHeaderValue(RepositoryName));

			Updates = new List<RepositoryRelease>();
		}

		public async Task CheckForReleasesAsync(Version currentVersion, bool allowPrereleases = false)
		{
			Updates.Clear();
			var releases = await github.Releases.GetPaginatedAsync(RepositoryOwnerName, RepositoryName, 1, 10);

			foreach (var release in releases)
			{
				if (!allowPrereleases && release.Prerelease)
				{
					continue;
				}

				var assets = await github.Releases.GetAllAssets(RepositoryOwnerName, RepositoryName, release.Id);

				var update = new RepositoryRelease(release, new List<ReleaseAsset>(assets), ReleaseVersionPattern);
				Updates.Add(update);
			}

			NotifyUpdatesAvailable(currentVersion);
		}

		public async Task DownloadReleaseAssetsAsync(RepositoryRelease update, string downloadLocation)
		{
			await Task.Run(new Action(() => {
                if (update.Assets.Count == 0)
                {
                    return;
                }

                var releaseFolderName = $@"{update.ID}_{update.Name}";
                var downloadReleaseLocationPath = $"{downloadLocation}/{releaseFolderName}";

                update.AssetsDownloadLocation = downloadReleaseLocationPath;

				foreach (var asset in update.Assets)
				{
					var id = asset.Id;
					var filename = asset.Name;
					var url = asset.BrowserDownloadUrl;
					var downloadAssetFilePath = $@"{downloadReleaseLocationPath }/{id}_{filename}";

					var request = (HttpWebRequest)WebRequest.Create(url);

					FileSystemExtensions.EnsureDirectory(downloadAssetFilePath);

					using (var response = (HttpWebResponse)request.GetResponse())
					using (var responseStream = response.GetResponseStream())
					using (var fileStream = new FileStream(downloadAssetFilePath, System.IO.FileMode.Create, FileAccess.Write))
					{
						responseStream.Seek(0, SeekOrigin.Begin);
						responseStream.CopyTo(fileStream);
					}

					var downloadedAsset = new DownloadedReleaseAsset(asset, downloadAssetFilePath);
					update.AssetsDownloaded.Add(downloadedAsset);
				}
			}));

			NotifyUpdateDownloaded(update);
		}

		private void NotifyUpdatesAvailable(Version currentVersion)
		{
			if (ApplicationUpdater == null)
			{
				return;
			}

			var relevantUpdates = new List<RepositoryRelease>();

			foreach (var update in Updates)
			{
				if (update.Version > currentVersion)
				{
					relevantUpdates.Add(update);
				}
			}

			if (relevantUpdates.Count > 0)
			{
				ApplicationUpdater.UpdatesAvailable(relevantUpdates);
			}
		}

		private void NotifyUpdateDownloaded(RepositoryRelease update)
		{
			ApplicationUpdater?.UpdateDownloaded(update);
		}
	}
}
