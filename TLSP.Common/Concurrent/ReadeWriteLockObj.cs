
using System.Threading;

namespace TLSP.Common.Concurrent
{
    public class ReadeWriteLockObj<T>
    {
        private readonly ReaderWriterLockSlim @lock = new ReaderWriterLockSlim();
        public T Instanse { get;  set; }

        public ReadeWriteLockObj(T ins)
        {
            Instanse = ins;
        }

        public T EnterReadLock()
        {
            @lock.EnterReadLock();
            return Instanse;
        }
        

        public T EnterUpgradeableReadLock()
        {
            @lock.EnterUpgradeableReadLock();
            return Instanse;
        }

        public T EnterWriteLock()
        {
            @lock.EnterWriteLock();
            return Instanse;
        }

        public T TryEnterReadLock(int millisecondsTimeout)
        {
            @lock.TryEnterReadLock(millisecondsTimeout);
            return Instanse;
        }

        public T TryEnterUpgradeableReadLock(int millisecondsTimeout)
        {
            @lock.TryEnterUpgradeableReadLock(millisecondsTimeout);
            return Instanse;
        }

        public T TryEnterWriteLock(int millisecondsTimeout)
        {
            @lock.TryEnterWriteLock(millisecondsTimeout);
            return Instanse;
        }

        public void ExitReadLock() => @lock.ExitReadLock();

        public void ExitUpgradeableReadLock() => @lock.ExitUpgradeableReadLock();

        public void ExitWriteLock() => @lock.ExitWriteLock();
    }
}
