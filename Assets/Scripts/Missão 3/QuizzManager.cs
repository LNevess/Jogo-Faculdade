using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizzManager : MonoBehaviour
{
	public GameObject TelaDerrota;
	public GameObject TelaVitoria;

	[Header("Acertos IMG")]
	public GameObject[] acertosIMGGameObject;
	[Header("Erros IMG")]
	public GameObject[] errosIMGGameObject;
	public XpBarAnimator1 xpAnimator;


	public int countAcerto, countErros;
	public int countGeral;

	[Space(2)]
	#region DESIGN
	[Header("Botões Design")]
	public Image[] imgButtosDesign;
	public Image imgButtonDesignMaster;
	[Space]
	public bool acertoDesign;
	public bool erroDesign;
	#endregion

	[Space(2)]
	#region PROGRAMAÇÃO
	[Header("Botões Prog")]
	public Image[] imgButtosProg;
	public Image imgButtonProgMaster;
	[Space]
	public bool acertoProg;
	public bool erroProg;
	#endregion

	[Space(2)]
	#region MATEMATICA
	[Header("Botões Mat")]
	public Image[] imgButtosMat;
	public Image imgButtonMatMaster;
	[Space]
	public bool acertoMat;
	public bool erroMat;
	#endregion

	[Space(2)]
	#region ETICA
	[Header("Botões Mat")]
	public Image[] imgButtosEtica;
	public Image imgButtonEticaMaster;
	[Space]
	public bool acertoEtica;
	public bool erroEtica;
	#endregion

	private void Start()
	{
		#region DESIGN
		acertoDesign = false;
		erroDesign = false;
		#endregion
		#region Prog
		acertoProg = false;
		erroProg = false;
		#endregion
	}
	private void Update()
	{
		#region DESIGN
		if (acertoDesign)
		{
			imgButtonDesignMaster.color = Color.green;
		}
		else if (erroDesign) 
		{
			imgButtonDesignMaster.color = Color.red;
		}
		#endregion
		#region Prog
		if (acertoProg)
		{
			imgButtonProgMaster.color = Color.green;
		}
		else if (erroProg)
		{
			imgButtonProgMaster.color = Color.red;
		}
		#endregion
		#region Mat
		if (acertoMat)
		{
			imgButtonMatMaster.color = Color.green;
		}
		else if (erroMat)
		{
			imgButtonMatMaster.color = Color.red;
		}
		#endregion
		#region Etica
		if (acertoEtica)
		{
			imgButtonEticaMaster.color = Color.green;
		}
		else if (erroEtica)
		{
			imgButtonEticaMaster.color = Color.red;
		}
		#endregion

		if (countGeral == 4 && countErros >= 1)
		{
			TelaDerrota.SetActive(true);
		}
		if (countGeral == 4 && countErros == 0)
		{
			TelaVitoria.SetActive(true);
			xpAnimator.StartXPAnimation(1f);
		}


	}
	#region DESIGN
	public void AcertoDesign()
	{
		if (erroDesign || acertoDesign) return;
		acertoDesign = true;
		acertosIMGGameObject[0].SetActive(true);
		countAcerto++;
		countGeral++;

		for (int i = 0; i < imgButtosDesign.Length; i++)
		{
			imgButtosDesign[i].color = Color.gray;
		}
	}
	public void ErroDesign()
	{
		if (erroDesign || acertoDesign) return;
		erroDesign = true;
		errosIMGGameObject[0].SetActive(true);
		countErros++;
		countGeral++;

		for (int i = 0; i < imgButtosDesign.Length; i++)
		{
			imgButtosDesign[i].color = Color.gray;
		}
	}
	#endregion
	#region PROG
	public void AcertoProg()
	{
		if (erroProg || acertoProg) return;
		acertoProg = true;
		acertosIMGGameObject[1].SetActive(true);
		countAcerto++;
		countGeral++;

		for (int i = 0; i < imgButtosProg.Length; i++)
		{
			imgButtosProg[i].color = Color.gray;
		}
	}
	public void ErroProg()
	{
		if (erroProg || acertoProg) return;
		erroProg = true;
		errosIMGGameObject[1].SetActive(true);
		countErros++;
		countGeral++;

		for (int i = 0; i < imgButtosProg.Length; i++)
		{
			imgButtosProg[i].color = Color.gray;
		}
	}
	#endregion
	#region Mat
	public void AcertoMat()
	{
		if (erroMat || acertoMat) return;
		acertoMat = true;
		acertosIMGGameObject[2].SetActive(true);
		countAcerto++;
		countGeral++;

		for (int i = 0; i < imgButtosMat.Length; i++)
		{
			imgButtosMat[i].color = Color.gray;
		}
	}
	public void ErroMat()
	{
		if (erroMat || acertoMat) return;
		erroMat = true;
		errosIMGGameObject[2].SetActive(true);
		countErros++; 
		countGeral++;

		for (int i = 0; i < imgButtosMat.Length; i++)
		{
			imgButtosMat[i].color = Color.gray;
		}
	}
	#endregion
	#region Etica
	public void AcertoEtica()
	{
		if (erroEtica || acertoEtica) return;
		acertoEtica = true;
		acertosIMGGameObject[3].SetActive(true);
		countAcerto++;
		countGeral++;

		for (int i = 0; i < imgButtosEtica.Length; i++)
		{
			imgButtosEtica[i].color = Color.gray;
		}
	}
	public void ErroEtica()
	{
		if (erroEtica || acertoEtica) return;
		erroEtica = true;
		errosIMGGameObject[3].SetActive(true);
		countErros++;
		countGeral++;

		for (int i = 0; i < imgButtosEtica.Length; i++)
		{
			imgButtosEtica[i].color = Color.gray;
		}
	}
	#endregion
}
