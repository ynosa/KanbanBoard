//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KanbanBoard.Shell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices;
    using System.ServiceModel.DomainServices.Client;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using KanbanBoard.Web;
    
    
    /// <summary>
    /// Context for the RIA application.
    /// </summary>
    /// <remarks>
    /// This context extends the base to make application services and types available
    /// for consumption from code and xaml.
    /// </remarks>
    public sealed partial class WebContext : WebContextBase
    {
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the WebContext class.
        /// </summary>
        public WebContext()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets the context that is registered as a lifetime object with the current application.
        /// </summary>
        /// <exception cref="InvalidOperationException"> is thrown if there is no current application,
        /// no contexts have been added, or more than one context has been added.
        /// </exception>
        /// <seealso cref="System.Windows.Application.ApplicationLifetimeObjects"/>
        public new static WebContext Current
        {
            get
            {
                return ((WebContext)(WebContextBase.Current));
            }
        }
        
        /// <summary>
        /// Gets a user representing the authenticated identity.
        /// </summary>
        public new User User
        {
            get
            {
                return ((User)(base.User));
            }
        }
    }
}
namespace KanbanBoard.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.DomainServices;
    using System.ServiceModel.DomainServices.Client;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using System.ServiceModel.Web;
    using System.Xml.Serialization;
    
    
    /// <summary>
    /// The 'Board' entity class.
    /// </summary>
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/KanbanBoard.Web")]
    public sealed partial class Board : Entity
    {
        
        private EntityCollection<BoardItem> _boardItems;
        
        private string _boardName;
        
        private Guid _id;
        
        private string _userName;
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();
        partial void OnBoardNameChanging(string value);
        partial void OnBoardNameChanged();
        partial void OnIdChanging(Guid value);
        partial void OnIdChanged();
        partial void OnUserNameChanging(string value);
        partial void OnUserNameChanged();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        public Board()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets the collection of associated <see cref="BoardItem"/> entity instances.
        /// </summary>
        [Association("Board_BoardItem", "Id", "BoardId")]
        [XmlIgnore()]
        public EntityCollection<BoardItem> BoardItems
        {
            get
            {
                if ((this._boardItems == null))
                {
                    this._boardItems = new EntityCollection<BoardItem>(this, "BoardItems", this.FilterBoardItems, this.AttachBoardItems, this.DetachBoardItems);
                }
                return this._boardItems;
            }
        }
        
        /// <summary>
        /// Gets or sets the 'BoardName' value.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(256)]
        public string BoardName
        {
            get
            {
                return this._boardName;
            }
            set
            {
                if ((this._boardName != value))
                {
                    this.OnBoardNameChanging(value);
                    this.RaiseDataMemberChanging("BoardName");
                    this.ValidateProperty("BoardName", value);
                    this._boardName = value;
                    this.RaiseDataMemberChanged("BoardName");
                    this.OnBoardNameChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'Id' value.
        /// </summary>
        [DataMember()]
        [Editable(false, AllowInitialValue=true)]
        [Key()]
        [RoundtripOriginal()]
        public Guid Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnIdChanging(value);
                    this.ValidateProperty("Id", value);
                    this._id = value;
                    this.RaisePropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'UserName' value.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(256)]
        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                if ((this._userName != value))
                {
                    this.OnUserNameChanging(value);
                    this.RaiseDataMemberChanging("UserName");
                    this.ValidateProperty("UserName", value);
                    this._userName = value;
                    this.RaiseDataMemberChanged("UserName");
                    this.OnUserNameChanged();
                }
            }
        }
        
        private void AttachBoardItems(BoardItem entity)
        {
            entity.Board = this;
        }
        
        private void DetachBoardItems(BoardItem entity)
        {
            entity.Board = null;
        }
        
        private bool FilterBoardItems(BoardItem entity)
        {
            return (entity.BoardId == this.Id);
        }
        
        /// <summary>
        /// Computes a value from the key fields that uniquely identifies this entity instance.
        /// </summary>
        /// <returns>An object instance that uniquely identifies this entity instance.</returns>
        public override object GetIdentity()
        {
            return this._id;
        }
    }
    
    /// <summary>
    /// The 'BoardItem' entity class.
    /// </summary>
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/KanbanBoard.Web")]
    public sealed partial class BoardItem : Entity
    {
        
        private EntityRef<Board> _board;
        
        private Guid _boardId;
        
        private Guid _id;
        
        private string _name;
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();
        partial void OnBoardIdChanging(Guid value);
        partial void OnBoardIdChanged();
        partial void OnIdChanging(Guid value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardItem"/> class.
        /// </summary>
        public BoardItem()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets or sets the associated <see cref="Board"/> entity.
        /// </summary>
        [Association("Board_BoardItem", "BoardId", "Id", IsForeignKey=true)]
        [XmlIgnore()]
        public Board Board
        {
            get
            {
                if ((this._board == null))
                {
                    this._board = new EntityRef<Board>(this, "Board", this.FilterBoard);
                }
                return this._board.Entity;
            }
            set
            {
                Board previous = this.Board;
                if ((previous != value))
                {
                    this.ValidateProperty("Board", value);
                    if ((previous != null))
                    {
                        this._board.Entity = null;
                        previous.BoardItems.Remove(this);
                    }
                    if ((value != null))
                    {
                        this.BoardId = value.Id;
                    }
                    else
                    {
                        this.BoardId = default(Guid);
                    }
                    this._board.Entity = value;
                    if ((value != null))
                    {
                        value.BoardItems.Add(this);
                    }
                    this.RaisePropertyChanged("Board");
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'BoardId' value.
        /// </summary>
        [DataMember()]
        [RoundtripOriginal()]
        public Guid BoardId
        {
            get
            {
                return this._boardId;
            }
            set
            {
                if ((this._boardId != value))
                {
                    this.OnBoardIdChanging(value);
                    this.RaiseDataMemberChanging("BoardId");
                    this.ValidateProperty("BoardId", value);
                    this._boardId = value;
                    this.RaiseDataMemberChanged("BoardId");
                    this.OnBoardIdChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'Id' value.
        /// </summary>
        [DataMember()]
        [Editable(false, AllowInitialValue=true)]
        [Key()]
        [RoundtripOriginal()]
        public Guid Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnIdChanging(value);
                    this.ValidateProperty("Id", value);
                    this._id = value;
                    this.RaisePropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'Name' value.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(256)]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnNameChanging(value);
                    this.RaiseDataMemberChanging("Name");
                    this.ValidateProperty("Name", value);
                    this._name = value;
                    this.RaiseDataMemberChanged("Name");
                    this.OnNameChanged();
                }
            }
        }
        
        private bool FilterBoard(Board entity)
        {
            return (entity.Id == this.BoardId);
        }
        
        /// <summary>
        /// Computes a value from the key fields that uniquely identifies this entity instance.
        /// </summary>
        /// <returns>An object instance that uniquely identifies this entity instance.</returns>
        public override object GetIdentity()
        {
            return this._id;
        }
    }
    
    /// <summary>
    /// The DomainContext corresponding to the 'KanbanBoardAuthenticationDomainService' DomainService.
    /// </summary>
    public sealed partial class KanbanBoardAuthenticationDomainContext : global::System.ServiceModel.DomainServices.Client.ApplicationServices.AuthenticationDomainContextBase
    {
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="KanbanBoardAuthenticationDomainContext"/> class.
        /// </summary>
        public KanbanBoardAuthenticationDomainContext() : 
                this(new WebDomainClient<IKanbanBoardAuthenticationDomainServiceContract>(new Uri("KanbanBoard-Web-KanbanBoardAuthenticationDomainService.svc", UriKind.Relative)))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="KanbanBoardAuthenticationDomainContext"/> class with the specified service URI.
        /// </summary>
        /// <param name="serviceUri">The KanbanBoardAuthenticationDomainService service URI.</param>
        public KanbanBoardAuthenticationDomainContext(Uri serviceUri) : 
                this(new WebDomainClient<IKanbanBoardAuthenticationDomainServiceContract>(serviceUri))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="KanbanBoardAuthenticationDomainContext"/> class with the specified <paramref name="domainClient"/>.
        /// </summary>
        /// <param name="domainClient">The DomainClient instance to use for this DomainContext.</param>
        public KanbanBoardAuthenticationDomainContext(DomainClient domainClient) : 
                base(domainClient)
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets the set of <see cref="User"/> entity instances that have been loaded into this <see cref="KanbanBoardAuthenticationDomainContext"/> instance.
        /// </summary>
        public EntitySet<User> Users
        {
            get
            {
                return base.EntityContainer.GetEntitySet<User>();
            }
        }
        
        /// <summary>
        /// Gets an EntityQuery instance that can be used to load <see cref="User"/> entity instances using the 'GetUser' query.
        /// </summary>
        /// <returns>An EntityQuery that can be loaded to retrieve <see cref="User"/> entity instances.</returns>
        public EntityQuery<User> GetUserQuery()
        {
            this.ValidateMethod("GetUserQuery", null);
            return base.CreateQuery<User>("GetUser", null, false, false);
        }
        
        /// <summary>
        /// Gets an EntityQuery instance that can be used to load <see cref="User"/> entity instances using the 'Login' query.
        /// </summary>
        /// <param name="userName">The value for the 'userName' parameter of the query.</param>
        /// <param name="password">The value for the 'password' parameter of the query.</param>
        /// <param name="isPersistent">The value for the 'isPersistent' parameter of the query.</param>
        /// <param name="customData">The value for the 'customData' parameter of the query.</param>
        /// <returns>An EntityQuery that can be loaded to retrieve <see cref="User"/> entity instances.</returns>
        public EntityQuery<User> LoginQuery(string userName, string password, bool isPersistent, string customData)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("userName", userName);
            parameters.Add("password", password);
            parameters.Add("isPersistent", isPersistent);
            parameters.Add("customData", customData);
            this.ValidateMethod("LoginQuery", parameters);
            return base.CreateQuery<User>("Login", parameters, true, false);
        }
        
        /// <summary>
        /// Gets an EntityQuery instance that can be used to load <see cref="User"/> entity instances using the 'Logout' query.
        /// </summary>
        /// <returns>An EntityQuery that can be loaded to retrieve <see cref="User"/> entity instances.</returns>
        public EntityQuery<User> LogoutQuery()
        {
            this.ValidateMethod("LogoutQuery", null);
            return base.CreateQuery<User>("Logout", null, true, false);
        }
        
        /// <summary>
        /// Creates a new EntityContainer for this DomainContext's EntitySets.
        /// </summary>
        /// <returns>A new container instance.</returns>
        protected override EntityContainer CreateEntityContainer()
        {
            return new KanbanBoardAuthenticationDomainContextEntityContainer();
        }
        
        /// <summary>
        /// Service contract for the 'KanbanBoardAuthenticationDomainService' DomainService.
        /// </summary>
        [ServiceContract()]
        public interface IKanbanBoardAuthenticationDomainServiceContract
        {
            
            /// <summary>
            /// Asynchronously invokes the 'GetUser' operation.
            /// </summary>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/KanbanBoardAuthenticationDomainService/GetUserDomainServiceFau" +
                "lt", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/KanbanBoardAuthenticationDomainService/GetUser", ReplyAction="http://tempuri.org/KanbanBoardAuthenticationDomainService/GetUserResponse")]
            [WebGet()]
            IAsyncResult BeginGetUser(AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginGetUser'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginGetUser'.</param>
            /// <returns>The 'QueryResult' returned from the 'GetUser' operation.</returns>
            QueryResult<User> EndGetUser(IAsyncResult result);
            
            /// <summary>
            /// Asynchronously invokes the 'Login' operation.
            /// </summary>
            /// <param name="userName">The value for the 'userName' parameter of this action.</param>
            /// <param name="password">The value for the 'password' parameter of this action.</param>
            /// <param name="isPersistent">The value for the 'isPersistent' parameter of this action.</param>
            /// <param name="customData">The value for the 'customData' parameter of this action.</param>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/KanbanBoardAuthenticationDomainService/LoginDomainServiceFault" +
                "", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/KanbanBoardAuthenticationDomainService/Login", ReplyAction="http://tempuri.org/KanbanBoardAuthenticationDomainService/LoginResponse")]
            IAsyncResult BeginLogin(string userName, string password, bool isPersistent, string customData, AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginLogin'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginLogin'.</param>
            /// <returns>The 'QueryResult' returned from the 'Login' operation.</returns>
            QueryResult<User> EndLogin(IAsyncResult result);
            
            /// <summary>
            /// Asynchronously invokes the 'Logout' operation.
            /// </summary>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/KanbanBoardAuthenticationDomainService/LogoutDomainServiceFaul" +
                "t", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/KanbanBoardAuthenticationDomainService/Logout", ReplyAction="http://tempuri.org/KanbanBoardAuthenticationDomainService/LogoutResponse")]
            IAsyncResult BeginLogout(AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginLogout'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginLogout'.</param>
            /// <returns>The 'QueryResult' returned from the 'Logout' operation.</returns>
            QueryResult<User> EndLogout(IAsyncResult result);
            
            /// <summary>
            /// Asynchronously invokes the 'SubmitChanges' operation.
            /// </summary>
            /// <param name="changeSet">The change-set to submit.</param>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/KanbanBoardAuthenticationDomainService/SubmitChangesDomainServ" +
                "iceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/KanbanBoardAuthenticationDomainService/SubmitChanges", ReplyAction="http://tempuri.org/KanbanBoardAuthenticationDomainService/SubmitChangesResponse")]
            IAsyncResult BeginSubmitChanges(IEnumerable<ChangeSetEntry> changeSet, AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginSubmitChanges'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginSubmitChanges'.</param>
            /// <returns>The collection of change-set entry elements returned from 'SubmitChanges'.</returns>
            IEnumerable<ChangeSetEntry> EndSubmitChanges(IAsyncResult result);
        }
        
        internal sealed class KanbanBoardAuthenticationDomainContextEntityContainer : EntityContainer
        {
            
            public KanbanBoardAuthenticationDomainContextEntityContainer()
            {
                this.CreateEntitySet<User>(EntitySetOperations.Edit);
            }
        }
    }
    
    /// <summary>
    /// The DomainContext corresponding to the 'KanbanBoardDomainService' DomainService.
    /// </summary>
    public sealed partial class KanbanBoardDomainContext : DomainContext
    {
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="KanbanBoardDomainContext"/> class.
        /// </summary>
        public KanbanBoardDomainContext() : 
                this(new WebDomainClient<IKanbanBoardDomainServiceContract>(new Uri("KanbanBoard-Web-KanbanBoardDomainService.svc", UriKind.Relative)))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="KanbanBoardDomainContext"/> class with the specified service URI.
        /// </summary>
        /// <param name="serviceUri">The KanbanBoardDomainService service URI.</param>
        public KanbanBoardDomainContext(Uri serviceUri) : 
                this(new WebDomainClient<IKanbanBoardDomainServiceContract>(serviceUri))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="KanbanBoardDomainContext"/> class with the specified <paramref name="domainClient"/>.
        /// </summary>
        /// <param name="domainClient">The DomainClient instance to use for this DomainContext.</param>
        public KanbanBoardDomainContext(DomainClient domainClient) : 
                base(domainClient)
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets the set of <see cref="BoardItem"/> entity instances that have been loaded into this <see cref="KanbanBoardDomainContext"/> instance.
        /// </summary>
        public EntitySet<BoardItem> BoardItems
        {
            get
            {
                return base.EntityContainer.GetEntitySet<BoardItem>();
            }
        }
        
        /// <summary>
        /// Gets the set of <see cref="Board"/> entity instances that have been loaded into this <see cref="KanbanBoardDomainContext"/> instance.
        /// </summary>
        public EntitySet<Board> Boards
        {
            get
            {
                return base.EntityContainer.GetEntitySet<Board>();
            }
        }
        
        /// <summary>
        /// Gets an EntityQuery instance that can be used to load <see cref="BoardItem"/> entity instances using the 'GetBoardItems' query.
        /// </summary>
        /// <returns>An EntityQuery that can be loaded to retrieve <see cref="BoardItem"/> entity instances.</returns>
        public EntityQuery<BoardItem> GetBoardItemsQuery()
        {
            this.ValidateMethod("GetBoardItemsQuery", null);
            return base.CreateQuery<BoardItem>("GetBoardItems", null, false, true);
        }
        
        /// <summary>
        /// Gets an EntityQuery instance that can be used to load <see cref="Board"/> entity instances using the 'GetBoards' query.
        /// </summary>
        /// <returns>An EntityQuery that can be loaded to retrieve <see cref="Board"/> entity instances.</returns>
        public EntityQuery<Board> GetBoardsQuery()
        {
            this.ValidateMethod("GetBoardsQuery", null);
            return base.CreateQuery<Board>("GetBoards", null, false, true);
        }
        
        /// <summary>
        /// Creates a new EntityContainer for this DomainContext's EntitySets.
        /// </summary>
        /// <returns>A new container instance.</returns>
        protected override EntityContainer CreateEntityContainer()
        {
            return new KanbanBoardDomainContextEntityContainer();
        }
        
        /// <summary>
        /// Service contract for the 'KanbanBoardDomainService' DomainService.
        /// </summary>
        [ServiceContract()]
        public interface IKanbanBoardDomainServiceContract
        {
            
            /// <summary>
            /// Asynchronously invokes the 'GetBoardItems' operation.
            /// </summary>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/KanbanBoardDomainService/GetBoardItemsDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/KanbanBoardDomainService/GetBoardItems", ReplyAction="http://tempuri.org/KanbanBoardDomainService/GetBoardItemsResponse")]
            [WebGet()]
            IAsyncResult BeginGetBoardItems(AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginGetBoardItems'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginGetBoardItems'.</param>
            /// <returns>The 'QueryResult' returned from the 'GetBoardItems' operation.</returns>
            QueryResult<BoardItem> EndGetBoardItems(IAsyncResult result);
            
            /// <summary>
            /// Asynchronously invokes the 'GetBoards' operation.
            /// </summary>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/KanbanBoardDomainService/GetBoardsDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/KanbanBoardDomainService/GetBoards", ReplyAction="http://tempuri.org/KanbanBoardDomainService/GetBoardsResponse")]
            [WebGet()]
            IAsyncResult BeginGetBoards(AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginGetBoards'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginGetBoards'.</param>
            /// <returns>The 'QueryResult' returned from the 'GetBoards' operation.</returns>
            QueryResult<Board> EndGetBoards(IAsyncResult result);
            
            /// <summary>
            /// Asynchronously invokes the 'SubmitChanges' operation.
            /// </summary>
            /// <param name="changeSet">The change-set to submit.</param>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/KanbanBoardDomainService/SubmitChangesDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/KanbanBoardDomainService/SubmitChanges", ReplyAction="http://tempuri.org/KanbanBoardDomainService/SubmitChangesResponse")]
            IAsyncResult BeginSubmitChanges(IEnumerable<ChangeSetEntry> changeSet, AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginSubmitChanges'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginSubmitChanges'.</param>
            /// <returns>The collection of change-set entry elements returned from 'SubmitChanges'.</returns>
            IEnumerable<ChangeSetEntry> EndSubmitChanges(IAsyncResult result);
        }
        
        internal sealed class KanbanBoardDomainContextEntityContainer : EntityContainer
        {
            
            public KanbanBoardDomainContextEntityContainer()
            {
                this.CreateEntitySet<Board>(EntitySetOperations.All);
                this.CreateEntitySet<BoardItem>(EntitySetOperations.All);
            }
        }
    }
    
    /// <summary>
    /// The 'User' entity class.
    /// </summary>
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/KanbanBoard.Web")]
    public sealed partial class User : Entity, global::System.Security.Principal.IIdentity, global::System.Security.Principal.IPrincipal
    {
        
        private string _name = string.Empty;
        
        private IEnumerable<string> _roles;
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnRolesChanging(IEnumerable<string> value);
        partial void OnRolesChanged();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets or sets the 'Name' value.
        /// </summary>
        [DataMember()]
        [Editable(false, AllowInitialValue=true)]
        [Key()]
        [RoundtripOriginal()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnNameChanging(value);
                    this.ValidateProperty("Name", value);
                    this._name = value;
                    this.RaisePropertyChanged("Name");
                    this.OnNameChanged();
                    this.RaisePropertyChanged("IsAuthenticated");
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'Roles' value.
        /// </summary>
        [DataMember()]
        [Editable(false)]
        public IEnumerable<string> Roles
        {
            get
            {
                return this._roles;
            }
            set
            {
                if ((this._roles != value))
                {
                    this.OnRolesChanging(value);
                    this.ValidateProperty("Roles", value);
                    this._roles = value;
                    this.RaisePropertyChanged("Roles");
                    this.OnRolesChanged();
                }
            }
        }
        
        string global::System.Security.Principal.IIdentity.AuthenticationType
        {
            get
            {
                return string.Empty;
            }
        }
        
        /// <summary>
        /// Gets a value indicating whether the identity is authenticated.
        /// </summary>
        /// <remarks>
        /// This value is <c>true</c> if <see cref="Name"/> is not <c>null</c> or empty.
        /// </remarks>
        public bool IsAuthenticated
        {
            get
            {
                return (true != string.IsNullOrEmpty(this.Name));
            }
        }
        
        string global::System.Security.Principal.IIdentity.Name
        {
            get
            {
                return this.Name;
            }
        }
        
        global::System.Security.Principal.IIdentity global::System.Security.Principal.IPrincipal.Identity
        {
            get
            {
                return this;
            }
        }
        
        /// <summary>
        /// Computes a value from the key fields that uniquely identifies this entity instance.
        /// </summary>
        /// <returns>An object instance that uniquely identifies this entity instance.</returns>
        public override object GetIdentity()
        {
            return this._name;
        }
        
        /// <summary>
        /// Return whether the principal is in the role.
        /// </summary>
        /// <remarks>
        /// Returns whether the specified role is contained in the roles.
        /// This implementation is case sensitive.
        /// </remarks>
        /// <param name="role">The name of the role for which to check membership.</param>
        /// <returns>Whether the principal is in the role.</returns>
        public bool IsInRole(string role)
        {
            if ((this.Roles == null))
            {
                return false;
            }
            return global::System.Linq.Enumerable.Contains(this.Roles, role);
        }
    }
}
