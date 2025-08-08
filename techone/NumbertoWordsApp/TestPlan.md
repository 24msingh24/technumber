# Test Plan

I tested the app manually with different inputs:

- Whole numbers: 123 → ONE HUNDRED AND TWENTY-THREE DOLLARS
- Decimals: 45.67 → FORTY-FIVE DOLLARS AND SIXTY-SEVEN CENTS
- Zero: 0 → ZERO DOLLARS
- Negative numbers: -12.34 → NEGATIVE TWELVE DOLLARS AND THIRTY-FOUR CENTS
- Large numbers: 1000000 → ONE MILLION DOLLARS
- Invalid input: letters or empty → shows error message

The app handles rounding cents correctly and shows messages when input is missing or wrong.

---

All tests gave expected results.
