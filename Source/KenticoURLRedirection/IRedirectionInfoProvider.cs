using CMS.DataEngine;

namespace KenticoURLRedirection
{
    /// <summary>
    /// Declares members for <see cref="RedirectionInfo"/> management.
    /// </summary>
    public partial interface IRedirectionInfoProvider : IInfoProvider<RedirectionInfo>, IInfoByIdProvider<RedirectionInfo>
    {
    }
}