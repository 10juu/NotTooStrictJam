using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFactory : Singleton<AbstractFactory>
{
   
    //Abstract Factory
   public interface IFactory<TFactory> {
        TProduct CreateProduct<TProduct>() where TProduct: IProduct<TFactory>, new();
   }

   //Abstract Product
   public interface IProduct<TFactory>
    {
        void spawn(Vector2 position, GameObject prefab, GameObject Player);//spawn Vector2 position, GameObject prefab
    }

    //Concrete Factory

    
    public class Enemy:IFactory<Enemy>{
      public TProduct CreateProduct<TProduct>() where TProduct: IProduct<Enemy>, new(){
         Debug.Log("Creating an Enemy Factory");
         return new TProduct();
      }    
   }

    public class TowerFactory:IFactory<TowerFactory>{
      public TProduct CreateProduct<TProduct>() where TProduct: IProduct<TowerFactory>, new(){
         Debug.Log("Creating a Tower Factory");
         return new TProduct();
      }    
   }
   //Concrete Products


   public class Tower : IProduct<TowerFactory>
   {
        public void spawn(Vector2 position, GameObject prefab, GameObject map){
         GameObject tower =  Instantiate(prefab, position, Quaternion.identity);
         tower.GetComponent<TowerMovement>().mapPosition = map.GetComponent<MapPosition>();


        } 

        /*
            spawnPoint

            knighht prefab

        */
        public void KnightSpecificOp()=> Debug.Log("Knight doing Knnight things");
   }
   public class Knight : IProduct<Enemy>
   {
        public void spawn(Vector2 position, GameObject prefab, GameObject Player){
         GameObject knight =  Instantiate(prefab, position, Quaternion.identity);
         knight.GetComponent<MoveToPlayer>().target = Player;


        } 

        /*
            spawnPoint

            knighht prefab

        */
        public void KnightSpecificOp()=> Debug.Log("Knight doing Knnight things");
   }
   public class Common : IProduct<Enemy>
   {
      public void spawn(Vector2 position, GameObject prefab, GameObject Player) {
             GameObject man =  Instantiate(prefab, position, Quaternion.identity);
               man.GetComponent<MoveToPlayer>().target = Player;
         }
      public void CommonSpecificOp()=> Debug.Log("man doing man things");
   }
    /**/public class Archer : IProduct<Enemy>
   {
      public void spawn(Vector2 position, GameObject prefab, GameObject Player) {
         GameObject man =  Instantiate(prefab, position, Quaternion.identity);
               //man.GetComponent<MoveToPlayer>().target = Player;
               }
      public void ArcherSpecificOp()=> Debug.Log("archer doing man archer");
   }
   //Client creates a concrete implementation of the abstract factory which is eventually used to create the concrete products.
   public class Factory<TFactory> where TFactory : IFactory<TFactory>, new(){
      public TProduct Create<TProduct>() where TProduct : IProduct<TFactory>, new(){
         return new TFactory().CreateProduct<TProduct>();
      }
   }
}




