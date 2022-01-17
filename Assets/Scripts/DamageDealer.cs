using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
    [SerializeField] int damage = 10;
    CountEnemyDestroyed enemiesDestroyed;

    private void Awake() {
        enemiesDestroyed = FindObjectOfType<CountEnemyDestroyed>();
    }

    public int GetDamage() {
        return damage;
    }

    public void Hit() {
        enemiesDestroyed.increateNumEnemyDestroyed();
        Destroy(gameObject);
    }
}

internal struct NewStruct {
    public object Item1;
    public object Item2;

    public NewStruct(object item1, object item2) {
        Item1 = item1;
        Item2 = item2;
    }

    public override bool Equals(object obj) {
        return obj is NewStruct other &&
               EqualityComparer<object>.Default.Equals(Item1, other.Item1) &&
               EqualityComparer<object>.Default.Equals(Item2, other.Item2);
    }

    public override int GetHashCode() {
        int hashCode = -1030903623;
        hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(Item1);
        hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(Item2);
        return hashCode;
    }

    public void Deconstruct(out object item1, out object item2) {
        item1 = Item1;
        item2 = Item2;
    }

    public static implicit operator (object, object)(NewStruct value) {
        return (value.Item1, value.Item2);
    }

    public static implicit operator NewStruct((object, object) value) {
        return new NewStruct(value.Item1, value.Item2);
    }
}