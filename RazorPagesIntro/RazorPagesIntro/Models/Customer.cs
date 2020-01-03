using System.ComponentModel.DataAnnotations;

namespace RazorPagesIntro.Models
{
    public class Customer
    {
        /*----------------------- PROPERTIES REGION ----------------------*/
        #region Properties

        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Name { get; set; }

        #endregion
        /*------------------------ METHODS REGION ------------------------*/
        #region Methods

        #endregion
    }
}