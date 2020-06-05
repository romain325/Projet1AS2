#COMPTE RENDU
==============


-------------------------------------------------

Nous cherchons à réaliser une application permettant à chaque amateur de découvrir à l’aide d’un algorithme proposant aux utilisateurs de découvrir de nouveaux produits en fonctions de leurs goûts, choix et impératifs. 
Voici l'ensemble des données à connaître pour pouvoir travailler de manière optimal sur ce projet

-------------------------------------------------

## CONTEXTE

Nous cherchons à réaliser une application permettant à chaque amateur de découvrir de nouvelles bières à l’aide d’un algorithme proposant aux utilisateurs de nouveaux produits en fonctions de leurs goûts, choix et impératifs. 
Via un système de recherche détaillé (type/origine/gout ...) l’utilisateur se verra recommander différents produits répondant aux critères recherchés. 
De plus, l’utilisateur aura accès à un espace personnel où via une page lui demandant quelle bière connue il aime pourra renseigner ses goûts et pourra suite à cela renseigner ses contraintes (intolérance/allergies ...) en terme de bière et se voir proposer des produits répondants à ses critères personnalisés. Cet espace permettra aussi à celui-ci d’utiliser un système de notations des différentes bières.
Le logiciel proposera aussi un mode découverte, exposant une bière recherchée aléatoirement selon un critère choisi parmi une liste de thèmes prédéfini et diversifié. 
Notre objectif est d'apporté aux utilisateurs une curiosité houblonné. Mais celui-ci sera surement plus renseigné sur certain sujet que l'application! Ainsi nous avons mis en place un système de proposition. Chaque utilisateur pourra proposer une nouvelle bière ou brasserie et celle-ci nous sera directement envoyé, puis après traitement par nos équipes nous metterons à jour nos base de données.
Ainsi les utilisateurs pourront eux aussi participer activement aux partages de nouvelles bières avec les autres utilisateurs!
Notre priorité est avant tout de créer un outil permettant à chacun de développer sa curiosité et pouvoir bien sûr, la satisfaire.
A travers une étude de marchés, nous avons remarqué qu'il existe en effet des applications semblables, après des recherches et analyse des commentaires donnés sur ces applications, celles-ci ont un retour indiquant qu'elles étaient très peu "amateur" friendly. Et quand au contexte de notre application nous pensons qu'il est justement important que nous fassions une application la plus adapté et guidante pour les amateurs, mais où les habitués et connaisseurs peuvent s'y retrouver aussi. 



##IDEES PRINCIPALES
 

###DICTIONNAIRE BIERE contenant pour chaque bière : 
	* Nom de la bière 
	* Nom de la brasserie 
	* Localisation 
	* Types (IPA/Lager) 
	* Couleur 
	* Apparence 
	* Prix Moyen  
	* Céréales Utilisés 
	* Degrés 
	* Spécificités 
	* Origine 
	* Arome (Amer/Aigre/Sucré) 
	* Amer ou Doux 
	* Image 
	* (Présentation --> texte) 
	* ?Potentiellement Notes? 


###DICTIONNAIRE BRASSERIE contenant pour chaque brasserie: 
	* Nom  
	* Description 
	* Localisation = Pays / departement
	* Liste de Bieres 
	* Image 


###Un Espace Utilisateur renseigné 

Celui ci contiendra les gouts, biere déjà bu, age, localisation , impératifs et tout les informations de notre client
Celui ci pourra aussi ajouter des produits à ses favoris ou encore une liste de bière l'intéressant
Il pourra aussi noter les produits qu'il a déjà gouté afin de donné une note communautaire aux différents produits!

###Menu Recherches central

Ce menu permet à l'utilisateur de rechercher tout type de bière à l'aide d'un menu de recherche précos et complet

###Mode découverte
Permet de découvrir des bières selon des critères scriptés que nous avons choisis (avec des petits jeux de mots -> nos brasseries ont du talent, les potions magique, les combattantes, les raffinés, etc....) ainsi que de l'aléatoire afin de ne pas toujours avoir les memes résultats!
Cela permet de toujours avoir du nouveau sans redondance, et toujours garder l'envie de découvrir de nouveaux produits pour l'utilisateur

###Une option guide de consommation permettant d’apprendre différentes choses sur la bieres: 
	* Types de verre 
	* Type de Distillation 
	* Différents Types expliqués 
	* Comment boire sa bière
	* Comprendre la distillation

##Public visé 
Nous visons avant tout les Amateurs // grand public
Ainsi nous offrons un accompagnement dans la découverte d'un monde houblonné
Nous lui apportons un suivi et des conseils personnalisés
Mais même si celui-ci est déjà connaisseur il pourra y trouver son intérêt à l'aide d'outil apportant des produits peu courants 
Ainsi meme un connaisseur pourra découvrir de nouveaux produits


#**USEFUL INFORMATIONS**
--------------------------------------------------------------
##Sketch:
	[Lien vers Description imagé](sketch/sketch_description.md)

##Persona:
	[Lien vers Didier](persona/Didier.pdf)
	[Lien vers Sarah](persona/Sarah.pdf)
	[Lien vers Ulysse](persona/Ulysse.pdf)

##UserStories
	*[Création d'nun compte](userStory/creaCompte.md)
	*[Modification du profil](userStory/modifProfil.md)
	*[Notation d'un Produit](userStory/noterUnProduit.md)
	*[Proposer Un Nouveau produit](userStory/proposNvProduit.md)
	*[Recherche Détaillé](userStory/rechDetaille.md)

##UseCaseDiagram
	![UseCase Diagram](UseCaseDiagram/UseCaseDiagram.png)



#TASK LIST
**Suivé l'avancement de notre projet à l'aide de cette Task-List!**
	- [x] Ecrire le contexte
	- [x] Ecrire les personas
	- [x] Faires les Sketchs
	- [x] Faire des UserStory
	- [ ] Faire les StoryBoard
	- [x] Créer Design sur Adobe XD
	- [x] Diagramme des utilisations
	- [ ] Coming soon ....