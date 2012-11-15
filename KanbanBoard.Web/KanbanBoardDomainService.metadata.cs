
namespace KanbanBoard.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
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

            public BoardItem BoardItem { get; set; }

            public string BoardName { get; set; }

            public Guid Id { get; set; }

            public string UserName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies BoardItemMetadata as the class
    // that carries additional metadata for the BoardItem class.
    [MetadataTypeAttribute(typeof(BoardItem.BoardItemMetadata))]
    public partial class BoardItem
    {

        // This class allows you to attach custom attributes to properties
        // of the BoardItem class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class BoardItemMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private BoardItemMetadata()
            {
            }

            public Board Board { get; set; }

            public Guid BoardId { get; set; }

            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
