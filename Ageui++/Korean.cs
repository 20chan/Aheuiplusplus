using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ageui__
{
    static class Korean
    {
        public struct HANGUL_INFO
        {
            public string isHangul;
            public char originalChar;
            public char[] chars;
        }
        public sealed class HangulJaso
        {
            public static readonly string HTable_ChoSung = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
            public static readonly string HTable_JungSung = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
            public static readonly string HTable_JongSung = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
            private static readonly ushort m_UniCodeHangulBase = 0xAC00;
            private static readonly ushort m_UniCodeHangulLast = 0xD79F;
            
            public HangulJaso() { }
            
            public static char MergeJaso(string choSung, string jungSung, string jongSung)
            {
                int ChoSungPos, JungSungPos, JongSungPos;
                int nUniCode;

                ChoSungPos = HTable_ChoSung.IndexOf(choSung);    // 초성 위치
                JungSungPos = HTable_JungSung.IndexOf(jungSung);   // 중성 위치
                JongSungPos = HTable_JongSung.IndexOf(jongSung);   // 종성 위치

                // 앞서 만들어 낸 계산식
                nUniCode = m_UniCodeHangulBase + (ChoSungPos * 21 + JungSungPos) * 28 + JongSungPos;

                // 코드값을 문자로 변환
                char temp = Convert.ToChar(nUniCode);

                return temp;
            }

            public static HANGUL_INFO DevideJaso(char hanChar)
            {
                int ChoSung, JungSung, JongSung;    // 초성,중성,종성의 인덱스
                ushort temp = 0x0000;                // 임시로 코드값을 담을 변수
                HANGUL_INFO hi = new HANGUL_INFO();

                //Char을 16비트 부호없는 정수형 형태로 변환 - Unicode
                temp = Convert.ToUInt16(hanChar);

                // 캐릭터가 한글이 아닐 경우 처리
                if ((temp < m_UniCodeHangulBase) || (temp > m_UniCodeHangulLast))
                {
                    hi.isHangul = "NH";
                    hi.originalChar = hanChar;
                    hi.chars = null;
                }
                else
                {
                    // nUniCode에 한글코드에 대한 유니코드 위치를 담고 이를 이용해 인덱스 계산.
                    int nUniCode = temp - m_UniCodeHangulBase;
                    ChoSung = nUniCode / (21 * 28);
                    nUniCode = nUniCode % (21 * 28);
                    JungSung = nUniCode / 28;
                    nUniCode = nUniCode % 28;
                    JongSung = nUniCode;

                    hi.isHangul = "H";
                    hi.originalChar = hanChar;
                    hi.chars = new char[] { HTable_ChoSung[ChoSung], HTable_JungSung[JungSung], HTable_JongSung[JongSung] };
                }

                return hi;
            }
        }
    }
}
