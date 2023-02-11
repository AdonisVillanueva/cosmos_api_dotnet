using Flurl.Http;
using System.Threading.Tasks;

namespace CosmosApi.Extensions
{
    internal static class TaskExtensions
    {
        public static T Sync<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }

        public static async Task<T> WrapExceptions<T>(this Task<T> task)
        {
            try
            {
                return await task.ConfigureAwait(false);
            }
            catch (FlurlParsingException ex)
            {
                throw new CosmosSerializationException(ex);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.WrapException();
            }
        }
    }
}