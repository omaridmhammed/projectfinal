using System;
using System.IO;
using System.Collections.Generic;

namespace GestionDesNotes
{
    // Classe representant un etudiant
    // Cette classe definit un etudiant avec des proprietes pour le numero d'etudiant, le nom, et le prenom.
    public class Etudiant
    {
        // Proprietes pour le numero d'etudiant, le nom et le prenom
        public int NumeroEtudiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        // Constructeur qui initialise l'etudiant avec les details fournis
        public Etudiant(int numeroEtudiant, string nom, string prenom)
        {
            NumeroEtudiant = numeroEtudiant;
            Nom = nom;
            Prenom = prenom;
        }
    }

    // Classe representant un cours
    // Cette classe definit un cours avec des proprietes pour le numero de cours, le code, et le titre.
    public class Cours
    {
        // Proprietes pour le numero de cours, le code, et le titre
        public int NumeroCours { get; set; }
        public string Code { get; set; }
        public string Titre { get; set; }

        // Constructeur qui initialise le cours avec les details fournis
        public Cours(int numeroCours, string code, string titre)
        {
            NumeroCours = numeroCours;
            Code = code;
            Titre = titre;
        }
    }

    // Classe representant une note
    // Cette classe definit une note avec des proprietes pour le numero d'etudiant, le numero de cours, et la note elle-meme.
    public class Notes
    {
        // Proprietes pour le numero d'etudiant, le numero de cours, et la note
        public int NumeroEtudiant { get; set; }
        public int NumeroCours { get; set; }
        public double Note { get; set; }

        // Constructeur qui initialise la note avec les details fournis
        public Notes(int numeroEtudiant, int numeroCours, double note)
        {
            NumeroEtudiant = numeroEtudiant;
            NumeroCours = numeroCours;
            Note = note;
        }
    }

    // Classe principale pour la gestion des notes
    // Classe principale qui gere les etudiants, les cours, et les notes.
    class Program
    {
        static void Main(string[] args)
        {
            // Listes pour stocker les etudiants, les cours, et les notes
            List<Etudiant> etudiants = new List<Etudiant>();
            List<Cours> cours = new List<Cours>();
            List<Notes> notes = new List<Notes>();

            // Boucle infinie pour afficher le menu jusqu'a ce que l'utilisateur decide de quitter
            while (true)
            {
                Console.WriteLine("Options disponibles :");
                Console.WriteLine("1. Ajouter un Etudiant");
                Console.WriteLine("2. Ajouter un Cours");
                Console.WriteLine("3. Ajouter des Notes");
                Console.WriteLine("4. Afficher le Releve de Notes");
                Console.WriteLine("5. Quitter");

                // Recupere le choix de l'utilisateur
                Console.Write("Choisissez une option : ");
                int choix = int.Parse(Console.ReadLine());

                // Execute l'action correspondante en fonction du choix de l'utilisateur
                switch (choix)
                {
                    case 1:
                        AjouterEtudiant(etudiants);
                        break;
                    case 2:
                        AjouterCours(cours);
                        break;
                    case 3:
                        AjouterNotes(notes);
                        break;
                    case 4:
                        AfficherReleve(etudiants, cours, notes);
                        break;
                    case 5:
                        return; // Quitte l'application
                }
            }
        }

        // Methode pour ajouter un etudiant
        // Ajoute un etudiant a la liste et sauvegarde ses informations dans un fichier
        static void AjouterEtudiant(List<Etudiant> etudiants)
        {
            Console.Write("Numero d'etudiant : ");
            int numeroEtudiant = int.Parse(Console.ReadLine());
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Prenom : ");
            string prenom = Console.ReadLine();

            // Cree un nouvel objet Etudiant et l'ajoute a la liste
            Etudiant etudiant = new Etudiant(numeroEtudiant, nom, prenom);
            etudiants.Add(etudiant);

            // Sauvegarde les informations de l'etudiant dans un fichier
            SauvegarderEtudiant(etudiant);
            Console.WriteLine("Etudiant ajoute avec succes !");
        }

        // Methode pour ajouter un cours
        // Ajoute un cours a la liste et sauvegarde ses informations dans un fichier
        static void AjouterCours(List<Cours> cours)
        {
            Console.Write("Numero du cours : ");
            int numeroCours = int.Parse(Console.ReadLine());
            Console.Write("Code : ");
            string code = Console.ReadLine();
            Console.Write("Titre : ");
            string titre = Console.ReadLine();

            // Cree un nouvel objet Cours et l'ajoute a la liste
            Cours course = new Cours(numeroCours, code, titre);
            cours.Add(course);

            // Sauvegarde les informations du cours dans un fichier
            SauvegarderCours(course);
            Console.WriteLine("Cours ajoute avec succes !");
        }

        // Methode pour ajouter des notes
        // Ajoute une note a la liste et sauvegarde les informations dans un fichier
        static void AjouterNotes(List<Notes> notes)
        {
            Console.Write("Numero d'etudiant : ");
            int numeroEtudiant = int.Parse(Console.ReadLine());
            Console.Write("Numero du cours : ");
            int numeroCours = int.Parse(Console.ReadLine());
            Console.Write("Note : ");
            double note = double.Parse(Console.ReadLine());

            // Cree un nouvel objet Notes et l'ajoute a la liste
            Notes noteObj = new Notes(numeroEtudiant, numeroCours, note);
            notes.Add(noteObj);

            // Sauvegarde les informations de la note dans un fichier
            SauvegarderNotes(noteObj);
            Console.WriteLine("Note ajoutee avec succes !");
        }

        // Methode pour afficher le releve de notes d'un etudiant
        // Affiche le releve de notes pour un etudiant specifique en chargeant les informations depuis les fichiers
        static void AfficherReleve(List<Etudiant> etudiants, List<Cours> cours, List<Notes> notes)
        {
            Console.Write("Numero d'etudiant : ");
            int numeroEtudiant = int.Parse(Console.ReadLine());
            string releve = ChargerEtudiant(numeroEtudiant);
            Console.WriteLine(releve);
        }

        // Methode pour sauvegarder les informations d'un etudiant dans un fichier
        static void SauvegarderEtudiant(Etudiant etudiant)
        {
            // Definit le chemin du fichier en utilisant le numero de l'etudiant
            string filePath = $"{etudiant.NumeroEtudiant}.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Numero d'etudiant : {etudiant.NumeroEtudiant}");
                writer.WriteLine($"Nom : {etudiant.Nom}");
                writer.WriteLine($"Prenom : {etudiant.Prenom}");
            }
        }

        // Methode pour sauvegarder les informations d'un cours dans un fichier
        static void SauvegarderCours(Cours cours)
        {
            // Definit le chemin du fichier en utilisant le numero du cours
            string filePath = $"{cours.NumeroCours}.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Numero du cours : {cours.NumeroCours}");
                writer.WriteLine($"Code : {cours.Code}");
                writer.WriteLine($"Titre : {cours.Titre}");
            }
        }

        // Methode pour sauvegarder les notes d'un etudiant dans un fichier
        static void SauvegarderNotes(Notes notes)
        {
            // Definit le chemin du fichier en utilisant le numero de l'etudiant et ajoute "_notes" pour le distinguer
            string filePath = $"{notes.NumeroEtudiant}_notes.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Numero du cours : {notes.NumeroCours}");
                writer.WriteLine($"Note : {notes.Note}");
            }
        }

        // Methode pour charger les informations d'un etudiant depuis les fichiers
        static string ChargerEtudiant(int numeroEtudiant)
        {
            // Definit les chemins des fichiers pour l'etudiant et ses notes
            string etudiantFilePath = $"{numeroEtudiant}.txt";
            string notesFilePath = $"{numeroEtudiant}_notes.txt";
            
            // Verifie si le fichier de l'etudiant existe
            if (File.Exists(etudiantFilePath))
            {
                // Charge les details de l'etudiant
                string releve = File.ReadAllText(etudiantFilePath);
                
                // Si le fichier des notes existe, ajoute les notes au releve
                if (File.Exists(notesFilePath))
                {
                    releve += "\n" + File.ReadAllText(notesFilePath);
                }
                return releve;
            }
            else
            {
                return "Etudiant non trouve.";
            }
        }
    }
}
