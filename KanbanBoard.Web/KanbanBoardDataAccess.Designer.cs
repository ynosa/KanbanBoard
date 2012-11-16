﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("KanbanBoardDatabaseModel", "FK_BoardItem_Board", "Board", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(KanbanBoard.Web.Board), "BoardItem", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(KanbanBoard.Web.BoardItem), true)]

#endregion

namespace KanbanBoard.Web
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class KanbanBoardDatabaseEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new KanbanBoardDatabaseEntities object using the connection string found in the 'KanbanBoardDatabaseEntities' section of the application configuration file.
        /// </summary>
        public KanbanBoardDatabaseEntities() : base("name=KanbanBoardDatabaseEntities", "KanbanBoardDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new KanbanBoardDatabaseEntities object.
        /// </summary>
        public KanbanBoardDatabaseEntities(string connectionString) : base(connectionString, "KanbanBoardDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new KanbanBoardDatabaseEntities object.
        /// </summary>
        public KanbanBoardDatabaseEntities(EntityConnection connection) : base(connection, "KanbanBoardDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Board> Boards
        {
            get
            {
                if ((_Boards == null))
                {
                    _Boards = base.CreateObjectSet<Board>("Boards");
                }
                return _Boards;
            }
        }
        private ObjectSet<Board> _Boards;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<BoardItem> BoardItems
        {
            get
            {
                if ((_BoardItems == null))
                {
                    _BoardItems = base.CreateObjectSet<BoardItem>("BoardItems");
                }
                return _BoardItems;
            }
        }
        private ObjectSet<BoardItem> _BoardItems;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Boards EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBoards(Board board)
        {
            base.AddObject("Boards", board);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the BoardItems EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBoardItems(BoardItem boardItem)
        {
            base.AddObject("BoardItems", boardItem);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="KanbanBoardDatabaseModel", Name="Board")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Board : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Board object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="userName">Initial value of the UserName property.</param>
        /// <param name="boardName">Initial value of the BoardName property.</param>
        public static Board CreateBoard(global::System.Guid id, global::System.String userName, global::System.String boardName)
        {
            Board board = new Board();
            board.Id = id;
            board.UserName = userName;
            board.BoardName = boardName;
            return board;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Guid _Id;
        partial void OnIdChanging(global::System.Guid value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                OnUserNameChanging(value);
                ReportPropertyChanging("UserName");
                _UserName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UserName");
                OnUserNameChanged();
            }
        }
        private global::System.String _UserName;
        partial void OnUserNameChanging(global::System.String value);
        partial void OnUserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String BoardName
        {
            get
            {
                return _BoardName;
            }
            set
            {
                OnBoardNameChanging(value);
                ReportPropertyChanging("BoardName");
                _BoardName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("BoardName");
                OnBoardNameChanged();
            }
        }
        private global::System.String _BoardName;
        partial void OnBoardNameChanging(global::System.String value);
        partial void OnBoardNameChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("KanbanBoardDatabaseModel", "FK_BoardItem_Board", "BoardItem")]
        public EntityCollection<BoardItem> BoardItems
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<BoardItem>("KanbanBoardDatabaseModel.FK_BoardItem_Board", "BoardItem");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<BoardItem>("KanbanBoardDatabaseModel.FK_BoardItem_Board", "BoardItem", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="KanbanBoardDatabaseModel", Name="BoardItem")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class BoardItem : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new BoardItem object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="boardId">Initial value of the BoardId property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static BoardItem CreateBoardItem(global::System.Guid id, global::System.Guid boardId, global::System.String name)
        {
            BoardItem boardItem = new BoardItem();
            boardItem.Id = id;
            boardItem.BoardId = boardId;
            boardItem.Name = name;
            return boardItem;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Guid _Id;
        partial void OnIdChanging(global::System.Guid value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid BoardId
        {
            get
            {
                return _BoardId;
            }
            set
            {
                OnBoardIdChanging(value);
                ReportPropertyChanging("BoardId");
                _BoardId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BoardId");
                OnBoardIdChanged();
            }
        }
        private global::System.Guid _BoardId;
        partial void OnBoardIdChanging(global::System.Guid value);
        partial void OnBoardIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("KanbanBoardDatabaseModel", "FK_BoardItem_Board", "Board")]
        public Board Board
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Board>("KanbanBoardDatabaseModel.FK_BoardItem_Board", "Board").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Board>("KanbanBoardDatabaseModel.FK_BoardItem_Board", "Board").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Board> BoardReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Board>("KanbanBoardDatabaseModel.FK_BoardItem_Board", "Board");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Board>("KanbanBoardDatabaseModel.FK_BoardItem_Board", "Board", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
