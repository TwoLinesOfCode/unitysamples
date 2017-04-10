using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enum;
using UnityEngine.Events;

public class SingleShotBulletScript : MonoBehaviour {

	private void Awake()
	{
		//props = GetComponent<BulletDataScript>();
		//var child = transform.GetChild(0).gameObject;
		//child.AddComponent<BulletDataScript>();
		//copyStuffOver(props, child.GetComponent<BulletDataScript>());

		//child.GetComponent<ProjectileScript>().PowerUp += props.OnPowerUp;

	}

	void Start () {

	}

	void Update()
	{
		if (transform.childCount == 0)
		{
			DestroyObject(gameObject);
		}
	}

	//void copyStuffOver(BulletDataScript source, BulletDataScript target)
	//{
	//	//StringBuilder code = new StringBuilder();
	//	//code.Append(@"public static class Mapper{
	//	//					public static BulletDataScript MapBulletData(BulletDataScript source, BulletDataScript target){");
	//	//foreach (var field in fields)
	//	//{
	//	//	code.Append(string.Format("target.{0} = source.{0}", field.Name)); 
	//	//}
	//	//code.Append("}}");

	//	//CSharpCodeProvider provider;
	//	target.speed = source.speed;
	//	target.shootDown = source.shootDown;
	//	target.fireRateDelay = source.fireRateDelay;
	//	target.damage = source.damage;
	//}

}
