/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.java.processingplatform;

/**
 *
 * @author malor
 */
public class Orchestrator {
        
        //Constructeur commenter pour la phase de test
        public Orchestrator(String textDocument) {
            WordFinder wordFinder = new WordFinder();
            int numberValideWord = wordFinder.findMatchingWord(textDocument);

            //Calcule nb mot dans la phrase
            String[] words = textDocument.split("\\s+");

            float coverage = (float)((numberValideWord*100)/words.length); 
            System.out.println(coverage + "%");
            
            //Contient le mot secret
            SecretFinder secretFinder = new SecretFinder();
            boolean secretWord = secretFinder.findSecretWord(textDocument);
        }     
}
