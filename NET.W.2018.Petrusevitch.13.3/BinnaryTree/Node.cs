namespace BinnaryTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The node of tree.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class Node<T> : IEnumerable, IEnumerable<T>
    {


        private readonly Comparison<T> _comparison;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="comprasion">
        /// Comparer for custom object.
        /// </param>
        public Node(IComparer<T> comprasion)
        {
            if (comprasion == null)
            {
                this._comparison = Comparer<T>.Default.Compare;
            }
            else
            {
                this._comparison = comprasion.Compare;
            }
        }

        /// <summary>
        /// Initializes a new node in tree.
        /// </summary>
        /// <param name="element">
        /// New Element in tree.
        /// </param>
        private Node(T element)
        {
            this.Element = element;
            this.Left = null;
            this.Right = null;
        }


        public T Element { get; private set; }

        public Node<T> Parrent { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public IEnumerable<T> InOrder() => this.InOrder(this.Parrent);

        public IEnumerable<T> PostOrder() => this.PostOrder(this.Parrent);

        public IEnumerable<T> PreOrder() => this.PreOrder(this.Parrent);

        /// <summary>
        /// The insert element in tree.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <exception cref="ArgumentNullException"> null checked.
        /// </exception>
        public void Insert(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Parrent == null)
            {
                this.Parrent = new Node<T>(element);
                return;
            }

            if (this._comparison(element, this.Parrent.Element) == 0 || this.Parrent.Element == null)
            {
                this.Parrent.Element = element;
                return;
            }

            if (this._comparison(element, this.Parrent.Element) > 0)
            {
                if (this.Parrent.Right == null)
                {
                    this.Parrent.Right = new Node<T>(element);
                }

                this.Insert(element, this.Parrent.Right, this.Parrent);
            }
            else
            {
                if (this.Parrent.Left == null)
                {
                    this.Parrent.Left = new Node<T>(element);
                }

                this.Insert(element, this.Parrent.Left, this.Parrent);
            }
        }

        /// <summary>
        /// The insert node in tree.
        /// </summary>
        /// <param name="element">
        /// The element in node.
        /// </param>
        /// <param name="node">
        /// The node.
        /// </param>
        /// <param name="parentNode">
        /// The parent node.
        /// </param>
        private void Insert(T element, Node<T> node, Node<T> parentNode)
        {
            if (this._comparison(element, node.Element) == 0 || node.Element == null)
            {
                node.Element = element;
                node.Parrent = parentNode;
                return;
            }

            if (this._comparison(element, node.Element) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(element);
                }

                this.Insert(element, node.Right, node);
            }
            else
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(element);
                }

                this.Insert(element, node.Left, node);
            }
        }

        /// <summary>
        /// The finde element in tree.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="Node"/>finded node.
        /// </returns>
        public Node<T> Finde(T element)
        {
            if (this._comparison(element, this.Parrent.Element) == 0)
            {
                return this.Parrent;
            }

            if (this._comparison(element, this.Parrent.Element) < 0)
            {
                return this.Finde(element, this.Parrent.Left);
            }
            else
            {
                return this.Finde(element, this.Parrent.Right);
            }
        }

        /// <summary>
        /// The finde element in tree.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="node">
        /// The left or right node.
        /// </param>
        /// <returns>
        /// The <see cref="Node"/>.
        /// </returns>
        private Node<T> Finde(T element, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (this._comparison(element, node.Element) == 0)
            {
                return node;
            }

            if (this._comparison(element, node.Element) < 0)
            {
                return this.Finde(element, node.Left);
            }
            else
            {
                return this.Finde(element, node.Right);
            }
        }

        /// <summary>
        /// The remove element from node
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        /// <exception cref="ArgumentNullException">null checked.
        /// </exception>
        /// <exception cref="ArgumentException">exsistens object.
        /// </exception>
        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (this.Finde(element) == null)
            {
                throw new ArgumentException($"Tree has not this {nameof(element)}");
            }

            var tempNode = this.Finde(element);

            if (tempNode.Right == null && tempNode.Left == null)
            {
                if (this._comparison(element, tempNode.Parrent.Left.Element) == 0)
                {
                    tempNode.Parrent.Left = null;
                }
                else
                {
                    tempNode.Parrent.Right = null;
                }

                return true;
            }

            if ((tempNode.Right != null && tempNode.Left == null) || (tempNode.Right == null && tempNode.Left != null))
            {
                var backUp = tempNode.Left ?? tempNode.Right;
                var backUpParrent = tempNode.Parrent;
                if (this._comparison(backUpParrent.Element, element) > 0)
                {
                    backUpParrent.Left = backUp;
                    backUp.Parrent = backUpParrent;
                    return true;
                }
                else
                {
                    backUpParrent.Right = backUp;
                    backUp.Parrent = backUpParrent;
                    return true;
                }
            }

            if (tempNode.Left != null && tempNode.Right != null)
            {
                var backUp = tempNode.Parrent.Right;
                while (backUp.Left != null)
                {
                    backUp = backUp.Left;
                }

                var backUpElement = backUp.Element;
                tempNode.Element = backUpElement;
                this.Remove(backUpElement);
                return true;
            }

            return false;
        }

        /// <summary>
        /// The pre order list.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>element collection.
        /// </returns>
        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Element;
            if (node.Left != null)
            {
                foreach (var n in this.PreOrder(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in this.PreOrder(node.Right))
                {
                    yield return n;
                }
            }
        }

        /// <summary>
        /// The in order list
        /// </summary>
        /// <param name="node">
        /// The root node.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>in order collection.
        /// </returns>
        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var n in this.InOrder(node.Left))
                {
                    yield return n;
                }
            }


            yield return node.Element;

            if (node.Right != null)
            {
                foreach (var n in this.InOrder(node.Right))
                {
                    yield return n;
                }
            }
        }

        /// <summary>
        /// The post order list.
        /// </summary>
        /// <param name="node">
        /// The root node.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>post order collection.
        /// </returns>
        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var n in this.PostOrder(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in this.PostOrder(node.Right))
                {
                    yield return n;
                }
            }

            yield return node.Element;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.InOrder(this.Parrent).GetEnumerator();
        }
    }
}
