﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WindowsServiceNextiva.Log
{
    //public class ObservableList<T> : ObservableCollection<T>
    //{
    //    public override event NotifyCollectionChangedEventHandler CollectionChanged;

    //    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    //    {
    //        using (BlockReentrancy())
    //        {
    //            NotifyCollectionChangedEventHandler eventHandler = CollectionChanged;
    //            if (eventHandler == null)
    //                return;

    //            Delegate[] delegates = eventHandler.GetInvocationList();

    //            //foreach (NotifyCollectionChangedEventHandler handler in delegates)
    //            //{
    //            //    DispatcherObject dispatcherObject = handler.Target as DispatcherObject;
    //            //    if (dispatcherObject != null && dispatcherObject.CheckAccess() == false)
    //            //    {
    //            //        dispatcherObject.Dispatcher.Invoke(DispatcherPriority.DataBind, handler, this, e);
    //            //    }
    //            //    else
    //            //    {
    //            //        handler(this, e);
    //            //    }
    //            //}
    //        }
    //    }

    //    private IDisposable BlockReentrancy()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
