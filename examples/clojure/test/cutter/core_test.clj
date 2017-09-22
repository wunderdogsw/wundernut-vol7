(ns cutter.core-test
  (:require [clojure.test :refer :all]
            [cutter.core :refer :all]))

(def two-cuts [{:size 2 :value 2} {:size 4 :value 5}])

(deftest with-two-cuts
  (testing "basic cutting"
    (is (= (cut-for-highest-value two-cuts 1) -1))
    (is (= (cut-for-highest-value two-cuts 2) 2))
    (is (= (cut-for-highest-value two-cuts 3) 1))
    (is (= (cut-for-highest-value two-cuts 4) 5))))

(def three-cuts [{:size 2 :value 3} {:size 3 :value 4} {:size 5 :value 6}])

(deftest with-three-cuts
  (testing "two smaller should win one bigger"
    (is (= (cut-for-highest-value three-cuts 5) 7))))
