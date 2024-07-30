using System;
using System.IO;
using System.Collections.Generic;


namespace GestionDesNotes
{
    // Classe pour représenter un étudiant
    public class Etudiant
    {
        public int NumeroEtudiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public Etudiant(int numeroEtudiant, string nom, string prenom)
        {
            NumeroEtudiant = numeroEtudiant;
            Nom = nom;
            Prenom = prenom;
        }
    }

    // Classe pour représenter un cours
    public class Cours
    {
        public int NumeroCours { get; set; }
        public string Code { get; set; }
        public string Titre { get; set; }

        public Cours(int numeroCours, string code, string titre)
        {
            NumeroCours = numeroCours;
            Code = code;
            Titre = titre;
        }
    }

    // Classe pour représenter une note
    public class Notes
    {
        public int NumeroEtudiant { get; set; }
        public int NumeroCours { get; set; }
        public double Note { get; set; }

        public Notes(int numeroEtudiant, int numeroCours, double note)
        {
            NumeroEtudiant = numeroEtudiant;
            NumeroCours = numeroCours;
            Note = note;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Etudiant> etudiants = new List<Etudiant>();
            List<Cours> cours = new List<Cours>();
            List<Notes> notes = new List<Notes>();

            while (true)
            {
                Console.WriteLine("Options disponibles :");
                Console.WriteLine("1. Ajouter un Étudiant");
                Console.WriteLine("2. Ajouter un Cours");
                Console.WriteLine("3. Ajouter des Notes");
                Console.WriteLine("4. Afficher le Relevé de Notes");
                Console.WriteLine("5. Quitter");

                Console.Write("Choisissez une option : ");
                int choix = int.Parse(Console.ReadLine());

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
                        return;
                }
            }
        }

        static void AjouterEtudiant(List<Etudiant> etudiants)
        {
            Console.Write("Numéro d'étudiant : ");
            int numeroEtudiant = int.Parse(Console.ReadLine());
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();

            Etudiant etudiant = new Etudiant(numeroEtudiant, nom, prenom);
            etudiants.Add(etudiant);
            SauvegarderEtudiant(etudiant);
            Console.WriteLine("Étudiant ajouté avec succès !");
        }

        static void AjouterCours(List<Cours> cours)
        {
            Console.Write("Numéro du cours : ");
            int numeroCours = int.Parse(Console.ReadLine());
            Console.Write("Code : ");
            string code = Console.ReadLine();
            Console.Write("Titre : ");
            string titre = Console.ReadLine();

            Cours course = new Cours(numeroCours, code, titre);
            cours.Add(course);
            SauvegarderCours(course);
            Console.WriteLine("Cours ajouté avec succès !");
        }

        static void AjouterNotes(List<Notes> notes)
        {
            Console.Write("Numéro d'étudiant : ");
            int numeroEtudiant = int.Parse(Console.ReadLine());
            Console.Write("Numéro du cours : ");
            int numeroCours = int.Parse(Console.ReadLine());
            Console.Write("Note : ");
            double note = double.Parse(Console.ReadLine());

            Notes noteObj = new Notes(numeroEtudiant, numeroCours, note);
            notes.Add(noteObj);
            SauvegarderNotes(noteObj);
            Console.WriteLine("Note ajoutée avec succès !");
        }

        static void AfficherReleve(List<Etudiant> etudiants, List<Cours> cours, List<Notes> notes)
        {
            Console.Write("Numéro d'étudiant : ");
            int numeroEtudiant = int.Parse(Console.ReadLine());
            string releve = ChargerEtudiant(numeroEtudiant);
            Console.WriteLine(releve);
        }

        static void SauvegarderEtudiant(Etudiant etudiant)
        {
            string filePath = $"{etudiant.NumeroEtudiant}.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Numéro d'étudiant : {etudiant.NumeroEtudiant}");
                writer.WriteLine($"Nom : {etudiant.Nom}");
                writer.WriteLine($"Prénom : {etudiant.Prenom}");
            }
        }

        static void SauvegarderCours(Cours cours)
        {
            string filePath = $"{cours.NumeroCours}.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Numéro du cours : {cours.NumeroCours}");
                writer.WriteLine($"Code : {cours.Code}");
                writer.WriteLine($"Titre : {cours.Titre}");
            }
        }

        static void SauvegarderNotes(Notes notes)
        {
            string filePath = $"{notes.NumeroEtudiant}_notes.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Numéro du cours : {notes.NumeroCours}");
                writer.WriteLine($"Note : {notes.Note}");
            }
        }

        static string ChargerEtudiant(int numeroEtudiant)
        {
            string etudiantFilePath = $"{numeroEtudiant}.txt";
            string notesFilePath = $"{numeroEtudiant}_notes.txt";
            if (File.Exists(etudiantFilePath))
            {
                string releve = File.ReadAllText(etudiantFilePath);
                if (File.Exists(notesFilePath))
                {
                    releve += "\n" + File.ReadAllText(notesFilePath);
                }
                return releve;
            }
            else
            {
                return "Étudiant non trouvé.";
            }
        }
    }
}
