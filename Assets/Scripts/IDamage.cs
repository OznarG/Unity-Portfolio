using UnityEngine;

public interface IDamage
{
    //Added methods abstracts they so they don't have to be deffined here but they are forced to be defined 
    abstract void TakeDamage(float amount);
    abstract void AddEffect(WoundTypes type, BodyParts bodyPart);

}
