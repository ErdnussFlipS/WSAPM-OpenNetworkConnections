using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GitHubUpdateManger.Model
{
	public class RepositoryRelease
	{
		private const string STANDARD_VERSION_PATTERN = @"(\d+(\.\d+){1,3})";

		private Release _githubRelease { get; set; }

		public int ID => _githubRelease.Id;

		public string Name => _githubRelease.Name;

        private string _versionPattern { get; set; }
        public Version Version { get; private set; }

		public DateTime PublishedAt => _githubRelease.CreatedAt.LocalDateTime;

		public string Description => _githubRelease.Body;

        public List<ReleaseAsset> Assets { get; internal set; }
        public List<DownloadedReleaseAsset> AssetsDownloaded { get; internal set; } = new List<DownloadedReleaseAsset>();
        public string AssetsDownloadLocation { get; internal set; }

		internal RepositoryRelease(Release release, List<ReleaseAsset> assets, string versionPattern)
		{
            _githubRelease = release ?? throw new ArgumentNullException(nameof(release));
			Assets = assets;
            _versionPattern = versionPattern ?? STANDARD_VERSION_PATTERN;

            ParseReleaseName();
		}

		private void ParseReleaseName()
		{
			var name = _githubRelease.Name;

			var result = Regex.Match(name, _versionPattern);

			if (result.Success)
			{
				var group = result.Groups[0];
				Version = new Version(group.Value);
			}
		}
	}
}
