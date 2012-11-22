
namespace KanbanBoard.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies BoardMetadata as the class
    // that carries additional metadata for the Board class.
    [MetadataTypeAttribute(typeof(Board.BoardMetadata))]
    public partial class Board
    {

        // This class allows you to attach custom attributes to properties
        // of the Board class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class BoardMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private BoardMetadata()
            {
            }

            public EntityCollection<BoardColumn> BoardColumns { get; set; }

            public string BoardName { get; set; }

            public Guid Id { get; set; }

            public string UserName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies BoardColumnMetadata as the class
    // that carries additional metadata for the BoardColumn class.
    [MetadataTypeAttribute(typeof(BoardColumn.BoardColumnMetadata))]
    public partial class BoardColumn
    {

        // This class allows you to attach custom attributes to properties
        // of the BoardColumn class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class BoardColumnMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private BoardColumnMetadata()
            {
            }

            public Board Board { get; set; }

            public Guid BoardId { get; set; }

            public Guid Id { get; set; }

            public string Name { get; set; }

            public short Position { get; set; }
            
            [Include]
            public EntityCollection<Task> Tasks { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TaskMetadata as the class
    // that carries additional metadata for the Task class.
    [MetadataTypeAttribute(typeof(Task.TaskMetadata))]
    public partial class Task
    {

        // This class allows you to attach custom attributes to properties
        // of the Task class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TaskMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TaskMetadata()
            {
            }

            public BoardColumn BoardColumn { get; set; }

            public Guid BoardColumnId { get; set; }

            [Required(AllowEmptyStrings = true)]
            public string Description { get; set; }

            public Guid Id { get; set; }

            public string Name { get; set; }

            public short Position { get; set; }
        }
    }
}
