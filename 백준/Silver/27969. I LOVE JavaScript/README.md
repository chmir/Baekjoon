# [Silver III] I LOVE JavaScript - 27969 

[문제 링크](https://www.acmicpc.net/problem/27969) 

### 성능 요약

메모리: 5572 KB, 시간: 52 ms

### 분류

자료 구조, 구현, 파싱, 스택, 문자열

### 제출 일자

2024년 7월 24일 00:14:18

### 문제 설명

<p>웹에서 데이터를 주고받기 위해 가장 많이 사용하는 포맷은 JSON(JavaScript Object Notation)이다. 그러나 프론트엔드 개발자인 설영이는 자바스크립트가 싫어서 자신만의 방법으로 데이터를 표기하기로 결정하였다. 그 방법은 바로 ASON(AGCU Script Object Notation)이다. ASON은 대괄호(<code>[ ]</code>) 안에 객체에 대한 정보를 표기하는 방법이다. ASON 객체는 다음과 같이 표기한다.</p>

<p><code>[ (원소) (원소) (원소) ... (원소) ]</code></p>

<p>이때 (원소)로 허용되는 것은 <strong>양의 정수 자료형</strong>의 표기, <strong>문자열 자료형</strong>의 표기<strong> </strong>또는 <strong>다른 ASON 객체</strong>의 표기이다. 원소와 원소 사이, 원소와 대괄호 사이에는 하나의 스페이스 문자(<code>' '</code>)가 반드시 들어가 있어야 하며, 기타 모든 공백 문자는 허용하지 않는다. 또한 어떤 원소도 포함하지 않는 빈 ASON 객체가 있을 수 있는데, 이 객체는 <code>[ ]</code>로 표기한다. <em>대괄호 사이에 하나의 스페이스 문자가 들어가 있음에 유의하시오.</em></p>

<p>각각의 자료형은 다음과 같이 표기한다.</p>

<ul>
	<li><strong>양의 정수 자료형</strong>: 십진법을 사용하여 <mjx-container class="MathJax" jax="CHTML" style="font-size: 109%; position: relative;"><mjx-math class="MJX-TEX" aria-hidden="true"><mjx-mn class="mjx-n"><mjx-c class="mjx-c31"></mjx-c></mjx-mn></mjx-math><mjx-assistive-mml unselectable="on" display="inline"><math xmlns="http://www.w3.org/1998/Math/MathML"><mn>1</mn></math></mjx-assistive-mml><span aria-hidden="true" class="no-mathjax mjx-copytext">$1$</span></mjx-container>자 이상 <mjx-container class="MathJax" jax="CHTML" style="font-size: 109%; position: relative;"><mjx-math class="MJX-TEX" aria-hidden="true"><mjx-mn class="mjx-n"><mjx-c class="mjx-c31"></mjx-c><mjx-c class="mjx-c37"></mjx-c></mjx-mn></mjx-math><mjx-assistive-mml unselectable="on" display="inline"><math xmlns="http://www.w3.org/1998/Math/MathML"><mn>17</mn></math></mjx-assistive-mml><span aria-hidden="true" class="no-mathjax mjx-copytext">$17$</span></mjx-container>자 이하의 숫자로 표기한다. 가장 높은 자리에는 <code>0</code>이 올 수 없다.</li>
	<li><strong>문자열 자료형</strong>: <mjx-container class="MathJax" jax="CHTML" style="font-size: 109%; position: relative;"><mjx-math class="MJX-TEX" aria-hidden="true"><mjx-mn class="mjx-n"><mjx-c class="mjx-c31"></mjx-c></mjx-mn></mjx-math><mjx-assistive-mml unselectable="on" display="inline"><math xmlns="http://www.w3.org/1998/Math/MathML"><mn>1</mn></math></mjx-assistive-mml><span aria-hidden="true" class="no-mathjax mjx-copytext">$1$</span></mjx-container>자 이상의 알파벳(<code>a, b, ..., z, A, B, ..., Z</code>)을 사용하여 표기한다. 대문자와 소문자가 혼용될 수 있다. 알파벳 이외의 문자는 사용될 수 없다. </li>
</ul>

<p>ASON 객체는 원소가 나열된 순서를 중요하게 생각하기 때문에, 원소가 나열된 순서가 다른 두 객체는 다른 ASON 객체이다. 따라서 하나의 ASON 객체를 표현하는 방식은 하나뿐이다. 어떤 문자열 <mjx-container class="MathJax" jax="CHTML" style="font-size: 109%; position: relative;"><mjx-math class="MJX-TEX" aria-hidden="true"><mjx-mi class="mjx-i"><mjx-c class="mjx-c1D446 TEX-I"></mjx-c></mjx-mi></mjx-math><mjx-assistive-mml unselectable="on" display="inline"><math xmlns="http://www.w3.org/1998/Math/MathML"><mi>S</mi></math></mjx-assistive-mml><span aria-hidden="true" class="no-mathjax mjx-copytext">$S$</span></mjx-container>에 대응되는 하나의 ASON 객체가 존재한다면, <mjx-container class="MathJax" jax="CHTML" style="font-size: 109%; position: relative;"><mjx-math class="MJX-TEX" aria-hidden="true"><mjx-mi class="mjx-i"><mjx-c class="mjx-c1D446 TEX-I"></mjx-c></mjx-mi></mjx-math><mjx-assistive-mml unselectable="on" display="inline"><math xmlns="http://www.w3.org/1998/Math/MathML"><mi>S</mi></math></mjx-assistive-mml><span aria-hidden="true" class="no-mathjax mjx-copytext">$S$</span></mjx-container>를 <strong>ASON 객체의 유효한 표기</strong>라 한다.</p>

<p>ASON 객체가 하나 있다면, 그 객체가 메모리에서 얼마큼의 용량을 차지하는지를 계산할 수 있다. ASON 객체의 용량은 다음과 같이 계산한다.</p>

<ul>
	<li>(해당 ASON 객체가 소유한 모든 원소의 용량의 합 <mjx-container class="MathJax" jax="CHTML" style="font-size: 109%; position: relative;"><mjx-math class="MJX-TEX" aria-hidden="true"><mjx-mo class="mjx-n"><mjx-c class="mjx-c2B"></mjx-c></mjx-mo><mjx-mn class="mjx-n"><mjx-c class="mjx-c38"></mjx-c></mjx-mn></mjx-math><mjx-assistive-mml unselectable="on" display="inline"><math xmlns="http://www.w3.org/1998/Math/MathML"><mo>+</mo><mn>8</mn></math></mjx-assistive-mml><span aria-hidden="true" class="no-mathjax mjx-copytext">$+ 8$</span></mjx-container>byte)</li>
</ul>

<p>또한 양의 정수 자료형 원소의 용량은 <mjx-container class="MathJax" jax="CHTML" style="font-size: 109%; position: relative;"><mjx-math class="MJX-TEX" aria-hidden="true"><mjx-mn class="mjx-n"><mjx-c class="mjx-c38"></mjx-c></mjx-mn></mjx-math><mjx-assistive-mml unselectable="on" display="inline"><math xmlns="http://www.w3.org/1998/Math/MathML"><mn>8</mn></math></mjx-assistive-mml><span aria-hidden="true" class="no-mathjax mjx-copytext">$8$</span></mjx-container>byte, 문자열 자료형 원소의 용량은 (문자열의 길이 <mjx-container class="MathJax" jax="CHTML" style="font-size: 109%; position: relative;"><mjx-math class="MJX-TEX" aria-hidden="true"><mjx-mo class="mjx-n"><mjx-c class="mjx-c2B"></mjx-c></mjx-mo><mjx-mn class="mjx-n"><mjx-c class="mjx-c31"></mjx-c><mjx-c class="mjx-c32"></mjx-c></mjx-mn></mjx-math><mjx-assistive-mml unselectable="on" display="inline"><math xmlns="http://www.w3.org/1998/Math/MathML"><mo>+</mo><mn>12</mn></math></mjx-assistive-mml><span aria-hidden="true" class="no-mathjax mjx-copytext">$+ 12$</span></mjx-container>byte)다. 빈 ASON 객체는 어떤 다른 원소도 소유하지 않으므로 <mjx-container class="MathJax" jax="CHTML" style="font-size: 109%; position: relative;"><mjx-math class="MJX-TEX" aria-hidden="true"><mjx-mn class="mjx-n"><mjx-c class="mjx-c38"></mjx-c></mjx-mn></mjx-math><mjx-assistive-mml unselectable="on" display="inline"><math xmlns="http://www.w3.org/1998/Math/MathML"><mn>8</mn></math></mjx-assistive-mml><span aria-hidden="true" class="no-mathjax mjx-copytext">$8$</span></mjx-container>byte만큼의 용량을 차지한다. ASON 객체의 유효한 표기가 주어지면, 그 객체의 용량을 계산하는 프로그램을 작성하시오.</p>

### 입력 

 <p>한 줄에 걸쳐, ASON 객체의 유효한 표기가 주어진다. 주어지는 문자열의 길이는 스페이스 문자를 제외하고 <mjx-container class="MathJax" jax="CHTML" style="font-size: 109%; position: relative;"><mjx-math class="MJX-TEX" aria-hidden="true"><mjx-mn class="mjx-n"><mjx-c class="mjx-c31"></mjx-c><mjx-c class="mjx-c35"></mjx-c></mjx-mn><mjx-mstyle><mjx-mspace style="width: 0.167em;"></mjx-mspace></mjx-mstyle><mjx-mn class="mjx-n"><mjx-c class="mjx-c30"></mjx-c><mjx-c class="mjx-c30"></mjx-c><mjx-c class="mjx-c30"></mjx-c></mjx-mn></mjx-math><mjx-assistive-mml unselectable="on" display="inline"><math xmlns="http://www.w3.org/1998/Math/MathML"><mn>15</mn><mstyle scriptlevel="0"><mspace width="0.167em"></mspace></mstyle><mn>000</mn></math></mjx-assistive-mml><span aria-hidden="true" class="no-mathjax mjx-copytext">$15\,000$</span></mjx-container> 이하이다.</p>

### 출력 

 <p>주어진 표기에 대응되는 ASON 객체의 용량이 몇 byte인지를 하나의 정수로 출력한다.</p>

