﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public class Reference
    {
        private int ID;
        private string libelle;
        private string reference;
        private string marque;
        private int quantite;

        #region Getters / Setters
        public int getID
        {
            get { return ID; }
            private set { ID = value; }
        }
        public string getLibelle
        {
            get { return libelle; }
            private set { libelle = value; }
        }
        public string getReference
        {
            get { return reference; }
            private set { reference = value; }
        }
        public string getMarque
        {
            get { return marque; }
            private set { marque = value; }
        }
        public int getQuantite
        {
            get { return quantite; }
            private set { quantite = value; }
        }
        #endregion

        #region Constructeur
        public Reference(string libelle, string reference, string marque, int quantite)
        {
            this.libelle = libelle;
            this.reference = reference;
            this.marque = marque;
            this.quantite = quantite;
         

        }
        #endregion
    }
}
