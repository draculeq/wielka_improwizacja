using UnityEngine;
using System.Collections;

public class AudioSpecTest : MonoBehaviour {

	float[] freqData = new float[8192];
	public AudioListener listener;
	
	float[] band;
	
	void Start()
	{
		if ( sampleInterval <= 0 ) throw new UnityException("sample interval must be greater than zero");

		int n = freqData.Length;
		int k = 0;
		for(var j=0;j<freqData.Length;j++)
		{
			n /= 2;
			if(n==0) break;
			k++;
		}
		band  = new float[k+1];
		for (int i=0;i<band.Length;i++)
		{
			band[i] = 0;
		}

		for(int i=0 ; i < 25; i ++ ) {
			mutationTable[i] = MOVE.DOWN;
			mutationTable[25+i] = MOVE.LEFT;
			mutationTable[50+i] = MOVE.RIGHT;
			mutationTable[75+i] = MOVE.UP;
		}

		StartCoroutine(_check= Check ());
		//InvokeRepeating("check", 0, 1f/15f); // update at 15 fps
	}

	IEnumerator _check;
	public int samplePointsNumber;
	public float sampleInterval;

	IEnumerator Check()
	{
		while ( true){ 
			yield return new WaitForSeconds(sampleInterval);
			AudioListener.GetOutputData (freqData,0);//.GetSpectrumData(freqData, 0, FFTWindow.Rectangular);
			
			int k = 0;
			int crossover = 2; 
			for(int i=0;i< freqData.Length;i++)
			{  
				var d = freqData[i];
				var b = band[k];       
				band[k] = (d > b)? d:b;   // find the max as the peak value in that frequency band.
				if ( i>crossover-3)
				{
					k++;
					crossover *= 2;   // frequency crossover point for each band.
				}  
			}

			float sum = 0;
			int offset = Mathf.FloorToInt(band.Length/samplePointsNumber);
			if ( offset == 0 ) throw new UnityException ("too many sample points");
			for (int i = 0 ; i < band.Length; i += offset ) {
				sum += band[i];
				band[i] = 0;
			}
			sum /= (float)samplePointsNumber;

			Debug.Log("Gen Move = " + ConvertToMove(sum));
		}
	}

	MOVE[] mutationTable = new MOVE[100];

	MOVE ConvertToMove ( float v ) {
		return mutationTable[Mathf.FloorToInt (v*100)];
	}
}
