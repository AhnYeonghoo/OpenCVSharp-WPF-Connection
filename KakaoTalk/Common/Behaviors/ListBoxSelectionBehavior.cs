using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using System.Collections.Specialized;

namespace Common.Behaviors
{
    public class ListBoxSelectionBehavior : Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            if (SelectedItems != null)
            {
                AssociatedObject.SelectedItems.Clear();
                foreach (var item in SelectedItems)
                {
                    AssociatedObject.SelectedItems.Add(item);
                }
            }
        }

        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(IList), typeof(ListBoxSelectionBehavior),
                new UIPropertyMetadata(null, SelectedItemsChanged));

        private static void SelectedItemsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var behavior = o as ListBoxSelectionBehavior;
            if (behavior is null) return;
            var oldValue = e.OldValue as INotifyCollectionChanged;
            var newValue = e.NewValue as INotifyCollectionChanged;

            if (oldValue is not null)
            {
                oldValue.CollectionChanged -= behavior.SourceCollectionChanged;
                behavior.AssociatedObject.SelectionChanged -= behavior.ListBoxSelectionChanged;
            }

            if (newValue is not null)
            {
                behavior.AssociatedObject.SelectedItems.Clear();
                foreach (var item in (IEnumerable)newValue)
                {
                    behavior.AssociatedObject.SelectedItems.Add(item);
                }

                behavior.AssociatedObject.SelectionChanged += behavior.ListBoxSelectionChanged;
                newValue.CollectionChanged += behavior.SourceCollectionChanged;
            }
        }

        private bool _isUpdatingTarget;
        private bool _isUpdatingSource;

        void SourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_isUpdatingSource) return;
            try
            {
                _isUpdatingTarget = true;
                if (e.OldItems is not null)
                {
                    foreach (var item in e.OldItems)
                    {
                        AssociatedObject.SelectedItems.Remove(item);
                    }
                }

                if (e.NewItems is not null)
                {
                    foreach (var item in e.NewItems)
                    {
                        AssociatedObject.SelectedItems.Add(item);
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Reset)
                    AssociatedObject.SelectedItems.Clear();
            }
            finally
            {
                _isUpdatingTarget = false;
            }
        }

        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isUpdatingTarget) return;
            var selectedItems = this.SelectedItems;
            if (selectedItems is null) return;

            try
            {
                _isUpdatingSource = true;

                if (AssociatedObject.SelectedItems.Count == 0)
                {
                    selectedItems.Clear();
                }
                else
                {
                    foreach (var item in e.RemovedItems)
                    {
                        selectedItems.Remove(item);
                    }
                }
                foreach (var item in e.AddedItems)
                {
                    selectedItems.Add(item);
                }

            }
            finally
            {
                _isUpdatingSource = false;
            }
        }
    }
}
