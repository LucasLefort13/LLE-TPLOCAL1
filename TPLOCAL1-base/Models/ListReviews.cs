using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace TPLOCAL1.Models
{
    public class ListReviews
    {
        /// <summary>
        /// Function to retrieve the list of reviews contained in an XML file
        /// </summary>
        /// <param name="file">file path</param>
        public List<Reviews> GetAvis(string file)
        {
            // Instantiate the list as empty 
            List<Reviews> listReviews = new List<Reviews>();
            // Creating an XMLDocument object  to retrieve data from the physical file
            XmlDocument xmlDoc = new XmlDocument();
            // Loading Data into the XmlDocument
            xmlDoc.Load(file);

            // Retrieving the nodes to  pass them as a Reviews object and then adding them to the 'listReviews' list
            // We loop on each node of  type XmlNode having for path "root/row" (cf structure of the xml file)
            // The SelectNodes method  retrieves all nodes with the specified path
            foreach (XmlNode node in xmlDoc.SelectNodes("root/row"))
            {
                // Retrieving data in child nodes
                string name = node["Nom"].InnerText;
                string firstName = node["Prenom"].InnerText;
                string avis = node["Avis"].InnerText;

                // Creating the Reviews Object to Add to the Results List
                Reviews review = new Reviews
                {
                    Name = name,
                    Prenom = firstName,
                    AvisDonne = avis
                };

                // Adding the object to the list
                listReviews.Add(review);
            }

            // The list formed by the treatment is returned to the calling method
            return listReviews;
        }
    }

    /// <summary>
    /// Object grouping data related to reviews.
    /// \n Can be modified
    /// </summary>
    public class Reviews
    {
        /// <summary>
        /// Surname
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Forename
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// Notice given (Possible values : O or N)
        /// </summary>
        public string AvisDonne { get; set; }
    }
}
