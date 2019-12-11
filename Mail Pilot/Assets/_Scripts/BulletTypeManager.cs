using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;


public class BulletTypeManager : MonoBehaviour
{
    public List<string> m_bulletTypes = new List<string>();



    private void Update()
    {
        BulletPoolManager.m_bulletTypes = m_bulletTypes;
    }
}

