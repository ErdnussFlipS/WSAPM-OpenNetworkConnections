using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUpdateManger.Library.CustomOctokit
{
	class GitHubClient : Octokit.GitHubClient
	{
		public ReleasesClient Releases { protected set; get; }

		public GitHubClient(ProductHeaderValue productInformation) : base(productInformation)
		{
			var apiConnection = new ApiConnection(Connection);
			Releases = new ReleasesClient(apiConnection);
		}
	}
}
