$fileContent = Get-Content -Path input.txt -Raw

$fileContent = $fileContent -replace "`n", "" -replace "`r", ""

$allMatches = $null
$allMatches = ([regex]'(?>mul\(\d+,\d+\))').Matches($fileContent)

$total = 0
foreach  ($match in $allMatches)
{
    $numMatches = ([regex]'(\d+)').Matches($match.Value);
    $value1 = [int]$numMatches[0].Value
    $value2 = [int]$numMatches[1].Value
    $total += ($value1 * $value2)
}

$total