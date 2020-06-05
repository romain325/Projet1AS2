#Création d'un compte

=================================

**En tant que** qu'utilisateur
**Je veux** me créer un compte
**Afin de** pouvoir avoir mon propre espace personnalisé

##Scénario 1
---------------------------------
Toutes les informations ont été rempli et sont valides ainsi son compte est mtn crée

##Scénario 2
---------------------------------
Il manque des informations essentiels ainsi nous le prévenons à l'aide d'un pop up et le laissons les corriger 
Cette notification apparait tant que toutes les informations ne sont pas juste

##Scénario 3
---------------------------------
L'Age indiqué est inférieur à 18ans ainsi nous affichons qu'il est impossible d'utiliser l'application 
Il sera stocké dans un fichier la date à laquelle l'utilisateur aura 18ans
Si l'application détecte que l'age ne convient pas alors l'appli se fermera en indiquant impossible
Si la date est dépassé alors l'accès est autorisé 