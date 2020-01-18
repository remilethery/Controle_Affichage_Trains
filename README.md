# Controle_Affichage_Trains
This double project uses the MVVM Pattern and ActiveMQUtils to send informations in a queue and get them in another MVVM project

This project was coded in a few days, using the MVVM pattern and WPF, the adapter pattern, as well as the observer patter.

The RealTimeTransportInfo sends informations in JSON format to an activeMQUtils queue.

The AffichageTempsReel4 project listens to the queue and displays the information in a WPF app with custom template.

You need an activeMQUtils server running to have the queue up and share informations between both apps.
