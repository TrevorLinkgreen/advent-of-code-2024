$fileContent = Get-Content -Path input.txt -Raw

$fileContent = $fileContent -replace "`n", "" -replace "`r", ""

$allMatches = $null
$allMatches = ([regex]'(?>mul\(\d+,\d+\))|(?>do\(\))|(?>don''t\(\))').Matches($fileContent)

$total = 0
$process = $true
foreach  ($match in $allMatches)
{
    if ($match.Value -eq "don't()")
    {
        $process = $false
    }
    if ($match.Value -eq "do()")
    {
        $process = $true
    }

    if ($process -eq $false) { continue; }

    $numMatches = ([regex]'(\d+)').Matches($match.Value);
    $value1 = [int]$numMatches[0].Value
    $value2 = [int]$numMatches[1].Value
    $total += ($value1 * $value2)
}

$total