using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Text;
//using Microsoft.CSharp;
//using System.CodeDom.Compiler;

public class TripleShotBulletScript : MonoBehaviour
{

	private void Awake()
	{
		var props = GetComponent<BulletDataScript>();
		//var target = new BulletDataScript();
		//FieldInfo[] fields = props.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
		//foreach (var field in fields)
		//{
		//	field.GetValue(target);
		//}

		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			var child = transform.GetChild(i).gameObject;
			child.AddComponent<BulletDataScript>();
			copyStuffOver(props, child.GetComponent<BulletDataScript>());
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.childCount == 0)
		{
			DestroyObject(gameObject);
		}
	}

	void copyStuffOver(BulletDataScript source, BulletDataScript target)
	{
		//StringBuilder code = new StringBuilder();
		//code.Append(@"public static class Mapper{
		//					public static BulletDataScript MapBulletData(BulletDataScript source, BulletDataScript target){");
		//foreach (var field in fields)
		//{
		//	code.Append(string.Format("target.{0} = source.{0}", field.Name)); 
		//}
		//code.Append("}}");

		//CSharpCodeProvider provider;
		target.speed = source.speed;
		target.shootDown = source.shootDown;
		target.fireRateDelay = source.fireRateDelay;
		target.damage = source.damage;
	}
}
