using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UsingIDisposable
{
    class FileCreator :IDisposable
    {
        FileStream fs;
        StreamWriter sw;
        public FileCreator(string path)
        {
            fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs.Close();
            sw = new StreamWriter(path);
        }

        public void Writing()
        {
           
            sw.Write("Unmaneged codes have already disposed!");
            sw.Close();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    sw.Dispose();
                    fs.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
                sw = null;
                fs = null;
            }
        }

       // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
         ~FileCreator()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
